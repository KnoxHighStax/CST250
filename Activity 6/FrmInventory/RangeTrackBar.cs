using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    // Extends Control which will put this item in the Toolbox as a UI item
    public class RangeTrackBar : Control
    {
        private int lowerValue = 10;
        private int upperValue = 90;
        private int minValue = 0;
        private int maxValue = 100;
        private int tickFrequency = 10;

        public Color LowerColor { get; set; } = Color.DarkRed;
        public Color UpperColor { get; set; } = Color.Teal;
        public Color TrackColor { get; set; } = Color.LightGray;
        public Color TickColor { get; set; } = Color.LightGray;
        public Color LabelColor { get; set; } = Color.Gray;

        private Rectangle lowerThumb;
        private Rectangle upperThumb;

        private bool draggingLower;
        private bool draggingUpper;

        // Declare the event using EventHandler
        // This will allow the event to be handled externally from a method in Form1.cs
        public event EventHandler MouseUp;

        // Custom setter for TickFrequency. Ensures that the value is always positive. Makes the property visible in the properties window
        public int TickFrequency
        {
            get => tickFrequency;
            set
            {
                // Ensuring that TickFrequency is always a positive value
                if (value > 0)
                {
                    tickFrequency = value;
                    // Redraw the control to reflect the change
                    Invalidate();
                }
                if (value > maxValue)
                {
                    tickFrequency = maxValue;
                }
            }
        }

        // Custom setter for MinValue. Ensures that the value is always positive. Makes the property visible in the properties window.
        public int MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                if (minValue > lowerValue)
                {
                    lowerValue = minValue;
                }
                if (minValue > upperValue)
                {
                    upperValue = minValue;
                }
                // Redraw the control to reflect the change. Invalidate() forces the control to be redrawn
                Invalidate();
            }
        }

        // Custom setter for MaxValue. Ensures that the value is always positive. Makes the property visible in the properties window
        public int MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                if (maxValue < lowerValue)
                {
                    lowerValue = maxValue;
                }
                if (maxValue < upperValue)
                {
                    upperValue = maxValue;
                }
                Invalidate();
            }
        }

        // Custom setter for LowerValue. Ensures that the value is always positive. Makes the property visible in the properties window
        public int LowerValue
        {
            get => lowerValue;
            set
            {
                // Ensure there's at least a difference of 1
                int newVal = Math.Min(Math.Max(value, minValue), upperValue);
                if (lowerValue != newVal)
                {
                    lowerValue = newVal;
                    UpdateThumbPositions();
                    Invalidate();
                }
            }
        }

        // Custom setter for UpperValue. Ensures that the value is always positive. Makes the property visible in the properties window
        public int UpperValue
        {
            get => upperValue;
            set
            {
                // Ensure there's at least a difference of 1
                int newVal = Math.Max(Math.Min(value, maxValue), lowerValue);
                if (upperValue != newVal)
                {
                    upperValue = newVal;
                    UpdateThumbPositions();
                    Invalidate();
                }
            }
        }

        public RangeTrackBar()
        {
            DoubleBuffered = true;
            MinimumSize = new Size(100, 50);
            UpdateThumbPositions();
        }

        private void UpdateThumbPositions()
        {
            int padding = 10;
            lowerThumb = new Rectangle(ValueToPosition(lowerValue, padding), 0, 10, 10);
            upperThumb = new Rectangle(ValueToPosition(upperValue, padding), 0, 10, 10);
        }

        private int ValueToPosition(int value, int padding)
        {
            double scale = (Width - 2 * padding) / (double)(maxValue - minValue);
            return (int)(padding + scale * (value - minValue));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggingLower = false;
            draggingUpper = false;

            // Manually invoke the OnClick event after mouse up
            OnClick(new EventArgs());

            // Trigger an event that can be handled externally, if needed
            MouseUp?.Invoke(this, e);
        }

        // This method draws the control. It is called when the control is first displayed and whenever it needs to be redrawn
        // The control has two polygons that represent the thumbs. The thumbs are drawn using the DrawThumb method
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the base class implements before proceeding withe teh custom drawing code
            base.OnPaint(e);
            // Padding on each side of the track
            int trackPadding = 10;
            Rectangle trackRect = new Rectangle(trackPadding, 5, Width - 2 * trackPadding, 1);

            using (Brush trackBrush = new SolidBrush(TrackColor))
            using (Pen tickPen = new Pen(TickColor))
            using (Brush lowerBrush = new SolidBrush(LowerColor))
            using (Brush upperBrush = new SolidBrush(UpperColor))
            using (Brush labelBrush = new SolidBrush(LabelColor))
            {
                e.Graphics.FillRectangle(trackBrush, trackRect);
                DrawThumb(e.Graphics, lowerThumb, lowerBrush);
                DrawThumb( e.Graphics, upperThumb, upperBrush);
                DrawTicks(e.Graphics, tickPen, trackRect);
                DrawLabels(e.Graphics, labelBrush);
            }
        }

        // Two numbers are drawn below the thumbs. The numbers represent the current value of the lower and upper thumbs
        private void DrawLabels(Graphics g, Brush labelBrush)
        {
            string lowerLabel = LowerValue.ToString();
            string upperLabel = UpperValue.ToString();
            SizeF lowerSize = g.MeasureString(lowerLabel, Font);
            SizeF upperSize = g.MeasureString(upperLabel, Font);
            g.DrawString(lowerLabel, Font, labelBrush, new PointF(lowerThumb.Left - (lowerSize.Width / 2) + 5, lowerThumb.Bottom + 6));
            g.DrawString(upperLabel, Font, labelBrush, new PointF(upperThumb.Left - (upperSize.Width / 2) + 5, upperThumb.Bottom + 6));
        }

        private void DrawTicks(Graphics g, Pen tickPen, Rectangle trackRect)
        {
            int tickNum = (maxValue - minValue) / tickFrequency;
            for (int i = 0; i <= tickNum; i++)
            {
                int x = trackRect.Left + (int)(i * (trackRect.Width / (double)tickNum));
                g.DrawLine(tickPen, x, trackRect.Top + 8, x, trackRect.Bottom + 10);
            }
        }

        private void DrawThumb(Graphics g, Rectangle thumbRect, Brush color)
        {
            // Set of points defines the shape of the thumb. The thumb is drawn as polygon with five points
            Point[] points = new Point[]
            {
                new Point(thumbRect.X, thumbRect.Y),
                new Point(thumbRect.X + thumbRect.Width, thumbRect.Y),
                new Point(thumbRect.X + thumbRect.Width, thumbRect.Y + thumbRect.Height),
                new Point(thumbRect.X + thumbRect.Width / 2, thumbRect.Y + thumbRect.Height + 10),
                new Point(thumbRect.X, thumbRect.Y + thumbRect.Height)
            };
            g.FillPolygon(color, points);
        }

        // This method is called when the suer clicks on the control. It chceks if teh user clicked on one of the thumbs of the track
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (lowerThumb.Contains(e.Location))
            {
                draggingLower = true;
            }
            else if (upperThumb.Contains(e.Location))
            {
                draggingUpper = true;
            }
            else
            {
                // Mouse is down on the track, so move the closet thumb
                int value = PositionToValue(e.X, 10);
                if (value < lowerValue)
                {
                    LowerValue = value;
                    draggingLower = true;
                }
                else if (value > upperValue)
                {
                    UpperValue = value;
                    draggingUpper = true;
                }
            }
            // If both sliders are at 0, then set the upper to be dragged
            if (upperValue == 0 && draggingLower == true)
            {
                draggingLower = false;
                draggingUpper = true;
            }
        }

        // This method is called when the user moves the mouse. It updates the position of the thumb that is being dragged
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!draggingLower && !draggingUpper) return;

            int value = PositionToValue(e.X, 10);
            if (draggingLower)
            {
                // Use property to trigger ValueChanges
                LowerValue = value;
            }
            else if (draggingUpper)
            {
                // Use property to trigger ValueChnages
                UpperValue = value;
            }
        }

        // This method is called when the control is resizes. It updates the position of the thumbs
        private void SetLowerValue(int value)
        {
            lowerValue = Math.Min(Math.Max(value, minValue), upperValue);
            UpdateThumbPositions();
            Invalidate();
        }

        // This method is called when the control is resized. It updates the position to the thumbs
        private void SetUpperValue(int value)
        {
            upperValue = Math.Min(Math.Max(value, minValue), lowerValue);
            UpdateThumbPositions();
            Invalidate();
        }

        // This method is used to determine the location of the mouse pointer in relation to the track. It returns the value that corresponds to the position of the mouse pointer
        private int PositionToValue(int position, int padding)
        {
            double scale = (Width - 2 * padding) / (double)(maxValue - minValue);
            return Math.Max(minValue, Math.Min(maxValue, (int)((position - padding) / scale + minValue)));
        }
    }
}

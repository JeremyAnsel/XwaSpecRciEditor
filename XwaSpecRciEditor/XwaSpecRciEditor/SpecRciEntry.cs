using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XwaSpecRciEditor
{
    public class SpecRciEntry
    {
        public SpecRciEntry()
        {
            this.Id = 0;
            this.TypeId = 0;
            this.Speed = 0;
            this.Acceleration = 0;
            this.Maneuverability = 0;
            this.Laser = 0;
            this.Ion = 0;
            this.Missile = 0;
            this.Shield = 0;
            this.Hull = 0;
            this.Size = 0;
            this.Score = 0;
        }

        public SpecRciEntry(int[] values)
        {
            this.SetValues(values);
        }

        public int Id { get; set; }

        public int TypeId { get; set; }

        public int Speed { get; set; }

        public int Acceleration { get; set; }

        public int Maneuverability { get; set; }

        public int Laser { get; set; }

        public int Ion { get; set; }

        public int Missile { get; set; }

        public int Shield { get; set; }

        public int Hull { get; set; }

        public int Size { get; set; }

        public int Score { get; set; }

        public int[] GetValues()
        {
            return new int[]{
                this.Id,
                this.TypeId,
                this.Speed,
                this.Acceleration,
                this.Maneuverability,
                this.Laser,
                this.Ion,
                this.Missile,
                this.Shield,
                this.Hull,
                this.Size,
                this.Score
            };
        }

        public void SetValues(int[] values)
        {
            if (values == null || values.Length != 12)
            {
                throw new ArgumentException("values cannot be a null reference and must contain 12 items");
            }

            this.Id = values[0];
            this.TypeId = values[1];
            this.Speed = values[2];
            this.Acceleration = values[3];
            this.Maneuverability = values[4];
            this.Laser = values[5];
            this.Ion = values[6];
            this.Missile = values[7];
            this.Shield = values[8];
            this.Hull = values[9];
            this.Size = values[10];
            this.Score = values[11];
        }
    }
}

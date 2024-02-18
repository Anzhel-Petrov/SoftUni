using System.Runtime.CompilerServices;
using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount { get { return this.Species.Count; } }

        public void AddShark(Shark shark)
        {
            if (this.Species.Count < this.Capacity)
            {
                if (!this.Species.Contains(shark))
                {
                    this.Species.Add(shark);
                }
            }
        }
        public bool RemoveShark(string kind)
        {
            return this.Species.Remove(this.Species.Where(x => x.Kind == kind).FirstOrDefault());
        }

        public string GetLargestShark()
        {
            return this.Species.MaxBy(x => x.Length).ToString();
        }

        public double GetAverageLength()
        {
            return this.Species.Select(x => x.Length).Average();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetCount} sharks classified:");
            foreach (Shark shark in this.Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}

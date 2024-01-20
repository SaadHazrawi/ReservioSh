namespace Reservio.DTOS.Clinic
{
    public class PatientInClinicDto
    {
        public string[] ClinicNames { get; set; }
        public int [] CountPatients { get; set; }
        public string[] RandomColor { get; set; }
    }

    public class DataObject
    {
        public List<string> Labels { get; set; }
        public List<Dataset> Datasets { get; set; }
    }

    public class Dataset
    {
        public List<int> Data { get; set; }
        public string Label { get; set; }
        public string BackgroundColor { get; set; }
    }

}

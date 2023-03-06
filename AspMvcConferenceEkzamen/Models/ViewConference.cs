namespace AspMvcConferenceEkzamen.Models
{
    public class ViewConference
    {
        public Conference Conferenc { get; set; }
        public IEnumerable<Conference> ArConference { get; set; }
    }
}

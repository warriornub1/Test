namespace OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request
{
    public class CreatePassageRequest
    {
        public int language_id { get; set; }
        public string passage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FinBeatTestExercise.Domain;

public class AbstractObject
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Code { get; set; }

    [Required]
    public string Value { get; set; } = string.Empty;
}

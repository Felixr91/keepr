using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string Img { get; set; }
    [Required]
    public int IsPrivate { get; set; }
    [Required]
    public int Views { get; set; }
    [Required]
    public int Shares { get; set; }
    [Required]
    public int Keeps { get; set; }
  }
}
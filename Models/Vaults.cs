using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Vault
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}
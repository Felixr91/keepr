using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  //helper model
  public class VaultToCreate
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string UserId { get; set; }
  }
  public class Vault
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public int Id { get; set; }
  }
}
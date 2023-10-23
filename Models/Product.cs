using System.ComponentModel.DataAnnotations;
using EmpMvc.Models;
public class Product{
    [Display(Name="Product Id")]
    [Key]
    [Required(ErrorMessage="Id is Compulsary")]
    public int Id{get;set;}
    [Required(ErrorMessage="Name cannot be Blank")]
    public string Name{get;set;}
    [Required(ErrorMessage = "Price should be between 100 and 900")]
    public int Price{get;set;}
    public int Stock{get;set;}

}
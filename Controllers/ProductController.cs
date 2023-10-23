using Microsoft.AspNetCore.Mvc;
using EmpMvc.Models;
using System.Data;
using System.Data.SqlClient;
namespace EmpMVC.Controllers;
public class ProductController:Controller{
    public IActionResult List(){
        string constr="User ID=sa;password=examlyMssql@123;server=localhost;Database=SajDb ;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        SqlConnection con=new SqlConnection(constr);
        SqlCommand command=new SqlCommand("Select * from product",con);
        con.Open();
        SqlDataReader reader=command.ExecuteReader();
        DataTable prodTable=new DataTable();
        prodTable.Load(reader);
        return View(prodTable);

    }
    public IActionResult Create(){
        return View();
    }
    [HttpPost]
    public IActionResult create(int id,string name,int Price,int stock){
        if(ModelState.IsValid){
            string constr="User ID=sa;password=examlyMssql@123;server=localhost;Database=SajDb ;trusted_connection=false;Persist Security Info=False;Encrypt=False";
            SqlConnection con=new SqlConnection(constr);
            SqlCommand command=new SqlCommand("addProduct",con);
            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("@name",name);
            command.Parameters.AddWithValue("@price",Price);
            command.Parameters.AddWithValue("@stock",stock);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("List");
        }
        return View();
    }
}
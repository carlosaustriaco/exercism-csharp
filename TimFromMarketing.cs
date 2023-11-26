using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idPart;
        string departmentPart;

        if (id == null)
        {
            idPart = "";
        }
        else
        {
            idPart = "[" + id.ToString() + "]" + " - "; 
        }

        if (department == null)
        {
            departmentPart = "OWNER";
        }
        else
        {
            departmentPart = department.ToUpper();
        }
        
        return idPart + name + " - " + departmentPart; 
    }
}

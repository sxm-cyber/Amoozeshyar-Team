using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Domain.Models
{
    public class Profile
    {
        public Guid Id { get;private set; }= Guid.NewGuid();

        public string Filename {  get; private set; }

        public string OrginalName { get; private set; }

        public DateTime UplaodedAt {  get; private set; }= DateTime.Now;



        public Profile(string filename,string orginalName) 
        {
            Filename = filename;
            OrginalName = orginalName;
        
        }

        public static Profile Create(string filename,string orginalName)
        {
            return new Profile(filename, orginalName);
        }

    }
}

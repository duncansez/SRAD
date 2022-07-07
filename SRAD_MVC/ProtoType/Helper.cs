using AutoMapper;
using SRAD_MVC.Models;
using SRAD_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRAD_MVC.ProtoType
{
    public static class Helper
    {
        public static GradeViewModel GradeUpdateViewModel(this Grade cDescription)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Grade, GradeViewModel>();
            });

            var Model = Mapper.Map<Grade, GradeViewModel>(cDescription);

            //get grade and remark
            if (Model.Score < 0)
            {
                Model.Grade = "F";
                Model.Result = "Gagal";
            }
            else if (Model.Score > 0 && Model.Score < 30)
            {
                Model.Grade = "F";
                Model.Result = "Gagal";
            }
            else if (Model.Score > 30 && Model.Score < 40)
            {
                Model.Grade = "E";
                Model.Result = "Gagal";
            }
            else if (Model.Score > 40 && Model.Score < 50)
            {
                Model.Grade = "D";
                Model.Result = "Lulus";
            }
            else if (Model.Score > 50 && Model.Score < 70)
            {
                Model.Grade = "C";
                Model.Result = "Lulus";
            }
            else if (Model.Score > 70 && Model.Score < 90)
            {
                Model.Grade = "B";
                Model.Result = "Lulus";
            }
            else if (Model.Score > 90 && Model.Score < 100)
            {
                Model.Grade = "A";
                Model.Result = "Lulus";
            }


            return Model;
        }
    }
}
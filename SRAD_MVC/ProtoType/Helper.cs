using AutoMapper;
using SRAD_MVC.ConstructionDesign;
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
        public static GradeViewModel GradeUpdateViewModel(this Grade grade)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Grade, GradeViewModel>();
            });

            var Model = Mapper.Map<Grade, GradeViewModel>(grade);

            //table based construction design
            //get grade and remark
            Model = TableBased.ProcessGrade(Model);


            return Model;
        }
    }
}
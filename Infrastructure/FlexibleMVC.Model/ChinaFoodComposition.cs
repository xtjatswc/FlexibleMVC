﻿using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;
using System;
using System.ComponentModel;

namespace FlexibleMVC.Model
{
    public class ChinaFoodComposition : BaseModel
    {
        [PrimaryKey()]
        public Int32 ChinaFoodComposition_DBKey { get; set; }
        public Int32 FoodCategory_DBKey { get; set; }
        public String FoodCode { get; set; }
        public String FoodName { get; set; }
        public String FoodFirstLetter { get; set; }
        public Int32 FoodTableInsideType { get; set; }
        public Single Water { get; set; }
        public Single Energy { get; set; }
        public Single EnergyKJ { get; set; }
        public Single Protein { get; set; }
        public Single Fat { get; set; }
        public Single Carbohydrate { get; set; }
        public Single TotalDietaryFiber { get; set; }
        public Single SolubleDietaryFiber { get; set; }
        public Single InsolubleDietaryFiber { get; set; }
        public Single Ash { get; set; }
        public Single Cholesterol { get; set; }
        public Single VitaminA { get; set; }
        public Single TotalCarotene { get; set; }
        public Single Thiamin { get; set; }
        public Single Riboflavin { get; set; }
        public Single VitaminB6 { get; set; }
        public Single VitaminB12 { get; set; }
        public Single Folate { get; set; }
        public Single Niacin { get; set; }
        public Single VitaminC { get; set; }
        public Single VitaminETotal { get; set; }
        public Single VitaminETE { get; set; }
        public Single Ca { get; set; }
        public Single P { get; set; }
        public Single K { get; set; }
        public Single Na { get; set; }
        public Single Mg { get; set; }
        public Single Fe { get; set; }
        public Single Zn { get; set; }
        public Single Se { get; set; }
        public Single Cu { get; set; }
        public Single Mn { get; set; }
        public Single I { get; set; }
        public Single Ile { get; set; }
        public Single Leu { get; set; }
        public Single Lys { get; set; }
        public Single SAATotal { get; set; }
        public Single Met { get; set; }
        public Single Cys { get; set; }
        public Single AAA { get; set; }
        public Single Phe { get; set; }
        public Single Tyr { get; set; }
        public Single Thr { get; set; }
        public Single Trp { get; set; }
        public Single Val { get; set; }
        public Single Arg { get; set; }
        public Single His { get; set; }
        public Single Ala { get; set; }
        public Single Asp { get; set; }
        public Single Glu { get; set; }
        public Single Gly { get; set; }
        public Single Pro { get; set; }
        public Single Ser { get; set; }
        public String FattyAcidTotal { get; set; }
        public String SFA { get; set; }
        public String MUFA { get; set; }
        public String PUFA { get; set; }
        public String UNK { get; set; }
        public String SFADvideTotal { get; set; }
        public String SFADvide60 { get; set; }
        public String SFADvide80 { get; set; }
        public String SFADvide100 { get; set; }
        public String SFADvide110 { get; set; }
        public String SFADvide120 { get; set; }
        public String SFADvide130 { get; set; }
        public String SFADvide140 { get; set; }
        public String SFADvide150 { get; set; }
        public String SFADvide160 { get; set; }
        public String SFADvide170 { get; set; }
        public String SFADvide180 { get; set; }
        public String SFADvide190 { get; set; }
        public String SFADvide200 { get; set; }
        public String SFADvide220 { get; set; }
        public String SFADvide240 { get; set; }
        public String MUFADvideTotal { get; set; }
        public String MUFADvide141 { get; set; }
        public String MUFADvide161 { get; set; }
        public String MUFADvide171 { get; set; }
        public String MUFADvide181 { get; set; }
        public String MUFADvide201 { get; set; }
        public String MUFADvide221 { get; set; }
        public String MUFADvide241 { get; set; }
        public String PUFADvideTotal { get; set; }
        public String PUFADivde162 { get; set; }
        public String PUFADivde182 { get; set; }
        public String PUFADivde183 { get; set; }
        public String PUFADivde184 { get; set; }
        public String PUFADivde202 { get; set; }
        public String PUFADivde203 { get; set; }
        public String PUFADivde204 { get; set; }
        public String PUFADivde205 { get; set; }
        public String PUFADivde223 { get; set; }
        public String PUFADivde224 { get; set; }
        public String PUFADivde225 { get; set; }
        public String PUFADivde226 { get; set; }
        public String UNKDvide { get; set; }
        public Single Cholin { get; set; }
        public Single Biotin { get; set; }
        public Single PantothenicAcid { get; set; }
        public Single VitK { get; set; }
        public Single VitD { get; set; }
        public String IsActive { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public String CreateProgram { get; set; }
        public String CreateIP { get; set; }
        public String UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public String UpdateProgram { get; set; }
        public String UpdateIP { get; set; }
        public Single FoodEdiblePart { get; set; }
        public Int32 MenuType { get; set; }
        public String imgSrc { get; set; }

    }
}

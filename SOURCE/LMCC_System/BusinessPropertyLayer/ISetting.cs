namespace BusinessPropertyLayer
{
    public interface ISetting
    {
        //DIVISION PROPERTIES
        string division { get; set; }
        string oldDivision { get; set; }


        //SURVEYOR PROPERTIES
        string surveyorType { get; set; }
        string existSurveyorType { get; set; }

        //LAND MARK PROPERTIES
        string landMarkType { get; set; }
        string existLandMarkType { get; set; }


        //COMMON DETAILS
        string common_division { get; set; }
        string common_username { get; set; }
        string common_district { get; set; }
        string common_snrss { get; set; }
    }
}

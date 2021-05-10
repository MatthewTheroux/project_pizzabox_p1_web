@model FirstCoreMVCApplication.Models.Student
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    <h1>@ViewBag.Header</h1>
    <div>
        StudentId : @Model.StudentId
    </div>
    <div>
        Name : @Model.Name
    </div>
    <div>
        Branch : @Model.Branch
    </div>
    <div>
        Section : @Model.Section
    </div>
    <div>
        Gender : @Model.Gender
    </div>
</body>
</html>

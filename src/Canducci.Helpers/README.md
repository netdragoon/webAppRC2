#Canducci Html MVC Helpers Core RC2 Final

[![NuGet](https://img.shields.io/nuget/v/CanducciHtmlMvcHelpersCoreRC2Final.svg?style=plastic&label=version)](https://www.nuget.org/packages/CanducciHtmlMvcHelpersCoreRC2Final/)

##NUGET

```Csharp
PM> Install-Package CanducciHtmlMvcHelpersCoreRC2Final
```
###Button Simply or Bootstrap Style

___How to?___
```csharp
<form method="post">

  <button-submit button-label="Gravar" button-css="p" button-style="Default"></button-submit>
  <button-submit button-label="Alterar" button-style="Success"></button-submit>
  <button-submit button-label="Salvar" button-style="Primary" button-glyphicon="Check"></button-submit>
  <button-submit button-glyphicon="Cog"></button-submit>
  <div>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="Default"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="DefaultAndBlock"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="ExtraSmall"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="ExtraSmallAndBlock"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="Large"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="LargeAndBlock"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="Small"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" 
          button-style="Success" button-size="SmallAndBlock"></button-submit>
  </div>
  <div>
      <button-submit button-glyphicon="Bold" button-label="Negrito" 
          button-style="Primary" button-size="Default" button-disabled="true"></button-submit>
      <button-submit button-glyphicon="Bold" button-label="Negrito" 
          button-style="Primary" button-size="Default"></button-submit>
  </div>  
  
</form>
```
__Example__

[![NuGet](https://github.com/netdragoon/helpWebForms/blob/master/Canducci.HtmlHelpers/button.png)](https://www.nuget.org/packages/CanducciHtmlMvcHelpersCoreRC2Final/)

###RadioButtonList
__How To?__
```csharp
<form asp-action="Edit">
    <div class="form-horizontal">
        <input asp-for="Id" type="hidden" />
        <h4>Pessoa</h4>
        <hr />
        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
        <div class="form-group">
            <label asp-for="Nome" class="col-md-2 control-label"></label>
            <div class="col-md-10">
                <input asp-for="Nome" class="form-control" />
                <span asp-validation-for="Nome" class="text-danger" />
            </div>
        </div>
        <div class="form-group">
            <label asp-for="Status" class="col-md-2 control-label"></label>
            <div class="col-md-10">
            
                <!--RADIOBUTTONLIST-->
                <radio-button-list radio-button-asp-for="Status"></radio-button-list>
                <!--RADIOBUTTONLIST-->
                
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>        
</form>
```
__Code__
```
protected void AddViewData()
  {
      var items = new object[]
      {
          new { Id = 1 , Name = "Branco" },
          new { Id = 2 , Name = "Azul" },
          new { Id = 3 , Name = "Verde" },
          new { Id = 3 , Name = "Marron" },
          new { Id = 3 , Name = "Vermelho" }
      };
      ViewData["Status"] = new RadioButtonList(items, "Id", "Name");
  }

  [HttpGet()]
  public IActionResult Edit(int id)
  {
      Pessoa p = new Pessoa() { Id = 1, Nome = "People", Status = 1 };
      AddViewData();
      return View(p);
  }
```

__Example__

[![Result](http://i1308.photobucket.com/albums/s610/maryjanexique/ave-ave_zpsp1qs0wah.png)](https://www.nuget.org/packages/CanducciHtmlMvcHelpersCoreRC2Final/)

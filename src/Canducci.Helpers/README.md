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
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="Default"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="DefaultAndBlock"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="ExtraSmall"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="ExtraSmallAndBlock"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="Large"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="LargeAndBlock"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="Small"></button-submit>
      <button-submit button-glyphicon="Music" button-label="Música" button-style="Success" button-size="SmallAndBlock"></button-submit>
  </div>
  <div>
      <button-submit button-glyphicon="Bold" button-label="Negrito" button-style="Primary" button-size="Default" button-disabled="true"></button-submit>
      <button-submit button-glyphicon="Bold" button-label="Negrito" button-style="Primary" button-size="Default"></button-submit>
  </div>  
  
</form>
```

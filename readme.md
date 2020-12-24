# [Survey.Net](https://www.nuget.org/packages/Survey.Net.Domain/) - Simple C# Survey Library

## Getting started
A "Getting started" as prescribed by tradition.  

### Installation
Command line: `dotnet add package Survey.Net.Domain --version 0.1.0`  
.csproj package reference: `<PackageReference Include="Survey.Net.Domain" Version="0.1.0" />`


### Examples
The `Survey` class is basically a container for survey pages and responses.  
Adding questions requires you to first add a `QuestionPage` to the survey.  

```c#
/*
 * Simple example of constructing a survey
 */
var survey = new Survey("Survey title");

//Add questions to survey.
// -- Any type implementing IQuestion can be added.
var firstPage = survey.AddPage<QuestionPage>("First page with questions");
firstPage.AddQuestion(new TextQuestion("What's your name?"));
firstPage.AddQuestion(new MultipleChoiceQuestion("Pick one", new [] {
    new Option("First option", "first value"),
    new Option("Second option", "second value"),
    new Option("Third option", 1),
}));


 // Add response to a question.
 // -- Response QuestionText property indicates which question the response is for.
survey.AddResponse(new Response(QuestionText: "What's your name?", Value: "Nicklas"));


// Get responses
string responsesAsJson = JsonConvert.SerializeObject(survey.Responses, Formatting.Indented);
Console.WriteLine(responsesAsJson);
```

The survey class provides a few navigation methods, such as moving forward and backwards through the survey pages.  

```c#
/*
 * Navigating the survey using its methods.
 */
var survey = new Survey("Survey");
            
// Calling AddPage<T> sets the CurrentPage to the newly created page.
survey.AddPage<QuestionPage>("First page");
survey.AddPage<QuestionPage>("Second page");
survey.AddPage<QuestionPage>("Third page");

ISurveyPage? lastPage = survey.CurrentPage;  // <- "Third page"
survey.PreviousPage();  // <- CurrentPage is now "Second page"
survey.NextPage();  // <- CurrentPage is back to "Third page".

survey.GoToPage(0); // <- CurrentPage is set to the first page
```

## Survey.Net concepts and approach to survey logic

The starting point is the `Survey`, and is the main object you should work with.  
A survey is composed of several parts several pages, which may be a front page, question page, or thank you page.

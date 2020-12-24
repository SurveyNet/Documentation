# [Survey.Net](https://www.nuget.org/packages/Survey.Net.Domain/) - Simple C# Survey Library

## Getting started

The `Survey` class is basically a container for survey pages and responses.  
Adding questions requires you to first add a `QuestionPage` to the survey.  
  
The survey class provides a few navigation methods, such as moving forward and backwards through the survey pages.  

```c#
var survey = new Survey("Survey title");

/*
 * Add questions to survey.
 * ---
 * Any type implementing IQuestion can be added.
 */
var firstPage = survey.AddPage<QuestionPage>("First page with questions");
firstPage.AddQuestion(new TextQuestion("What's your name?"));
firstPage.AddQuestion(new MultipleChoiceQuestion("Pick one", new [] {
    new Option("First option", "first value"),
    new Option("Second option", "second value"),
    new Option("Third option", 1),
}));


/*
 * Add response to a question.
 * ---
 * Response QuestionText property indicates which question the response is for.
 */
survey.AddResponse(new Response(QuestionText: "What's your name?", Value: "Nicklas"));


/*
 * Get responses
 */
string responsesAsJson = JsonConvert.SerializeObject(survey.Responses, Formatting.Indented);
Console.WriteLine(responsesAsJson);
```


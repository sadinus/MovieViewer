# MovieViewer
The application uses swapi API (https://swapi.dev/) for generating a list of movies. A user can vote for any movie, any number of times and the average from votes will be displayed.

The main requirement was to code it within 1 hours, so plenty of stuff were implemented badly:
- form validation wasn't implemented, so user can submit a form without passing value (it will be 0, as 0 is the default value),
- lack of commit history,
- a better project structure could be done,
- EF queries could be better (AsNoTracking, selecting only needed columns),
- the layout is poor.

Normally I wouldn't make an app using .NET Core MVC, because I think it's obsolete. Nowadays usage of Web API with Single Page Application technology is a desired thing.

# Budderfly MAUI Test

This app is a demo for a position at Budderfly.

There are two screens - MainPage is for viewing the list of all energy saving tips, and EnergySavingTipEntryPage is for entering new tips. The app uses an AppShell for navigation to properly work with DependencyInjection, which allows access to a DAL for saving the list of energy saving tips. Each tip is saved in a local database with a auto-incrementing Id.

A list of pre-existing tips is generated on first launch via an included json file, which is deserialized and saved to the local database.
The app also uses Preferences to save the option of whether to include a picture with the new tip.
There is also a unit testing project included in the solution, which has a few tests to ensure the form validation works, which prevents the user from saving a new tip without including both a Title and a Description.

# projektlol

Continuation of a school project, keeping at this for fun an education. 

# TO DO
## Refractor
Identifiers are all over the place. Need to figure out some naming convention and change all of this to make sense and make the app easier to develop. 

## Rework save function. 
The current save is a real hackjob and saves to AppData. Need to rework it completely. 
* Rework the writing and reading to a serializer of some sort. 
* Rework to allow manual save path or at the very least save to app folder. 
* Look into and potentially use SQLite for the savefile instead. The app is supposed to mirror a complete CRM and Stockpile management system for a small store, and the amount of data saved could potentially be a lot of text.

## Look over the GUI.
There's some wonky stuff going on behind the GUI. Maybe needs reworking?? who knows. 

# ICTOAN
*I can't think of a name* 

Hi!  
So this is a little framework of sorts I've been working on. I tend to make small applications a lot, usually in WPF. Things to test some .NET functionalities, some projects to challenge my logic, some ideas from my *programming bucket list*.  
During this, I found myself time and time again using the same core logic for navigation between pages, but it never felt... great. It worked, yes, but in no way was it good code.

This project was born out of thinking about this a bunch. In no way is it perfect, but it's something I'm proud of and personally use :D

also the icon was made in 5 min in GIMP. Someone told me "Hey, try making it a chameleon", so here it is.

Of course, feel free to use it for your own projects. **It's free!** *please do let me know though: I'd love to hear what people make ^^*

## HOW TO USE IT?
Start by downloading the .ZIP file from [the download Drive](https://drive.google.com/file/d/1-CWHXzJwdBhxLjUhmmk4yIxg7RQQ7_oU/view?usp=sharing). Copy it to your Visual Studio Templates folder, most likely situated at: `C:\Users\username\Documents\Visual Studio 2022\My Exported Templates`. When creating a new project, you can now start with the template.


## HOW DOES IT WORK?

### Host Window
This is the window where all content is displayed. You create the Pages you want in, well, the Pages folder, add them to the Page Organiser and tadaa! Now, the Host simply uses a Frame to host your content in automatically. The default page (home page, if you will) can be set in the code-behind.

Code related though, it simply listens for events from the Navigation Manager, from where is derived which page to load into the frame.

<br ><hr />


### Navigation Organiser
If you're aware of .NET MAUI Shell navigation, this part will be familiar, as it's heavily inspired by it.

A private stack of Page Types is kept and adjusted by every navigation command received. Navigating to / from a page will add / remove one item from the stack, before loading the highest item.

- Suppose we begin on `MainPage` => Stack: {`MainPage`,`FirstPage`}
- Navigate to `SecondPage` => Stack: {`MainPage`,`FirstPage`,`SecondPage`}
- Navigate back => Stack: {`MainPage`,`FirstPage`}
- Navigate to menu (`MainPage` as parameter) => Stack: {`MainPage`}

In every page that can navigate to somewhere else (this is, usually, all of them) you will have to include the navigator to use its functions.

<br ><hr />

### Page Organiser
This class keeps track of all pages and their instance with a `Dictionary<Type,object>`. It is used by the HostWindow to convert the received type to a page.

> For Transient pages/items, add an exception in HostWindow code-behind to create a new instance. The Page Organiser turns Transient pages into Singletons, essentially.

Every page you use has to be registered in this list. They must be added through the constructor of PageOrganiser and added to the public list. 


<br > <hr >

### Dependency Injection
As mentioned before, this template makes use of Dependency Injection. The services can be added in the `App.xaml.cs` file. I've provided a few examples. It's not too complicated (:

<br > <hr >


And... that's about it. This readme will probably get updated at some point, maybe some better documentation / explanation of how to make use of this all, maybe something else. 

*Good luck, enjoy!*

<3
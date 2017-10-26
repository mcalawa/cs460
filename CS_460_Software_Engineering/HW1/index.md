<link rel="stylesheet" href="css/styles.css">

<nav>
    <div class="navbar">
        <h1>CS 460 Homework 1</h1>
        <ul>
            <li><a href="https://mcalawa.github.io/senior_project/CS_460_Software_Engineering/HW1/" class="active">Home</a></li>
            <li><a href="games.html">Games</a></li>
            <li><a href="anime.html">Anime</a></li>
            <li><a href="english.html">Words</a></li>
            <li><a href="https://mcalawa.github.io/senior_project/">Portfolio Home</a></li>
        </ul>
    </div>
</nav>

# CS 460 Homework 1
* [Home](https://mcalawa.github.io/senior_project/CS_460_Software_Engineering/HW1/)
* [Games](games.html)
* [Anime](anime.html)
* [Words](english.html)
* [Portfolio Home](https://mcalawa.github.io/senior_project/)

## General Information

In homework 1, you must first begin by creating a Git repository. One of the main goals is to learn Git, so you should be making multiple commits as you go along. You are also required to make a website with a unified design, an example of both single column layout and two or more column formatting, a seperate CSS file with your own classes, a navigation bar/menu with links to all of your pages, at least one table, examples of `<ol>`, `<ul`, and `<dl>`, and a page with code that summarizes your process in completing the assignment.

The homework assignment page can be found [here](//www.wou.edu/~morses/classes/cs46x/assignments/HW1.html) and the GitHub repository for this particular assignment can be found [here](//github.com/mcalawa/senior_project/tree/master/CS_460_Software_Engineering/HW1).

## Primary Objectives

* Learn Git `init`, `add`, `commit`, `status`, `log`, `config`, `remote`, `fetch`, `pull`, `push`
* Learn about remote repositories with Bitbucket, GitHub, or GitLab
* Learn HTML
* Learn CSS
* Learn Bootstrap
* Demonstrate you know how to "submit" your work to the instructor
* Demonstrate your understanding of the Portfolio plan for the class

## Overall Requirements

1. Use Git from the command line only
2. Write (mostly) HTML 5
3. All files are under source control and synchronized with your remote Git repository, which is public
4. You have multiple commits on most files
5. Cloning your repo results in a working site (prove this by cloning it to you P: drive or some other web server)
6. You have a working GitHub Pages repository/web page meeting the requirements described below and during class
7. Any HTML or CSS notes, cheat sheets, or documentation has been put into your Portfolio in an organized fashion

## Some Example Git

I was a little bit intimidated by working with Git, so after initially creating the repository, I left updating it alone for a while while I had far too much fun working with HTML, CSS, and even previewing some JavaScript. However, after I got over my early nerves, Git proved to be relatively simple. So here's how you set up and update a Git repository.

```bash
git init
git remote add origin https://github.com/mcalawa/senior_project.git
```

## All About Lists

We were required to have at least one of each type of list. My `<ul>` is actually my navigation with styling to remove the bullet points and made the list items appear horizontal rather than vertical.

```html
<nav>
    <div class="navbar">
        <h1>CS 460 Homework 1</h1>
        <ul>
            <li><a href="https://mcalawa.github.io/senior_project/CS_460_Software_Engineering/HW1/" class="active">Home</a></li>
            <li><a href="games.html">Games</a></li>
            <li><a href="anime.html">Anime</a></li>
            <li><a href="english.html">Words</a></li>
            <li><a href="https://mcalawa.github.io/senior_project/">Portfolio Home</a></li>
        </ul>
    </div>
</nav>
```

The `<nav>` tag marks something as navigation, while the `<div>` with the class navbar is used to apply the background color and as a wrapper to more specifically target the elements I'll be styling. The `<ul>` tag marks an unordered list and each `<li>` tag represents a list item. In this case, the list items are all links to the various pages. The main styles of note that I used for the navigation bar were `{float: left;}`, which makes the list items float to a single line arranged from left to right, and `{list-style: none;}`, which removes the bullet points on an unordered list. Both of these styles were applied to `li` tags of the class navbar.

The ordered list is pretty similar to the unordered list. You just use an `<ol>`instead of a `<ul>` and it will give you a nice numbered list instead of one will bullet points. The final type of list is a definition list. I don't think definition lists were actually a thing when I first learned HTML back in the early 2000s (my Neopets days) and then more formerly in the latter half of the first decade of the 21st century. As the name would suggest, definition lists are used for defining things. Here is an example of a definition list in action.

```html
<h2>Great Opening Lines</h2>
<dl>
    <dt><em>Invitation to a Beheading</em> by Vladimir Nabokov</dt>
    <dd>In accordance with the law the death sentence was announced to Cincinnatus C. in a whisper.</dd>
    <dt><em>The Great Gatsby</em> by F. Scott Fitzgerald</dt>
    <dd>In my younger and more vulnerable years my father game me some advice that I've been turning over in my mind ever since.</dd>
    <dt><em>The Voyage of the Dawn Treader</em> by C.S. Lewis</dt>
    <dd>There was a boy called Eustace Clarence Scrubb, and he almost deserved it.</dd>
    <dt><em>The Third Policeman</em> by Flann O'Brien</dt>
    <dd>"Not everybody knows how I killed old Phillip Mathers, smashing his jaw in with my spade; but first it is better to speak of my friendship with John Divney because it was he who first knocked old Mathers down by giving him a great blow in the neck with a special bicycle-pump which he manufactured himself out of a hollow iron bar."</dd>
    <dt><em>The Defense</em> by Vladimir Nabokov</dt>
    <dd>What struck him most was the fact that from Monday on he would be Luzhin.</dd>
</dl>
```

The `<dt>` tag represents a term and the `<dd>` tag represents that term's definition. In this example, the terms are books and their authors and the definition of a book is the opening line(s) of that particular book.

## Tables

For my example of a table, I decided I wanted to catalogue some of the video games I own. My table ended up being fairly long, so I will only display part of it here as an example.

```html
<table class="tableData">
     <thead>
         <tr>
             <th onclick="sortTableBy(0)">Game</th>
             <th onclick="sortTableBy(1)">Series</th>
             <th onclick="sortTableBy(2)">System</th>
             <th onclick="sortTableBy(3)">Developer</th>
             <th onclick="sortTableBy(4)">Publisher</th>
             <th onclick="sortTableBy(5)">Year</th>
             <th>Beaten?</th>
         </tr>
     </thead>
     <tbody>
         <tr>
             <td>Phoenix Wright: Ace Attorney Trilogy</td>
             <td>Ace Attorney</td>
             <td>Nintendo 3DS (digital)</td>
             <td>Capcom</td>
             <td>Capcom</td>
             <td>2014</td>
             <td>Yes</td>
         </tr>
     </tbody>
 </table>
 ```
 A table is wrapped in (what else but) a `<table>` tag. Mine has a class of tableData because I wanted to be able to reorganize the data in the data by the different categories. There are then two types of content for the table (these are optional but make styling easier), the `<thead>`, which is used for the first row of your table and holds the categories that tell you what is in each column of the table, and the `<tbody>`, which has the actual data you are working with. Each row of the table, whether in the head or the body, is wrapped in `<tr>` (table row) tags. Columns within a row are represented by `<th>` (table header) tags in the head and `<td>` (table data) tags in the body. If you choose to ommit the `<thead>` and `<tbody>` tags, all of the columns will use `<td>`. As you can see, I also included some Javascript in some of my `<th>` tags so that I could implement a sort by the various categories. (I won't include the code I used for the sort in this write up as it's long and wasn't actually part of the assignment, but was just something that I did because I wanted to, but you can find the code in GitHub if you want to see it.)
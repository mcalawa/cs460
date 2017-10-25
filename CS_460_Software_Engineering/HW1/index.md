<!-- DOCTYPE -->
<!DOCTYPE html>
<html lang="en">
  <head>
    <title>CS 460 Homework 1</title>
    <meta charset="utf-8">
    <!-- Viewport Meta Tag -->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" integrity="sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ" crossorigin="anonymous">
    <!-- Main Style Sheet -->
    <link rel="stylesheet" href="css/styles.css">
  </head>
  <body>
	
	
    <!-- YOUR CONTENT STARTS HERE -->
    
    <nav>
       <div class="navbar">
          <h1>CS 460 Homework 1</h1>
           <ul>
            <li><a href="index.md" class="active">Home</a></li>
            <li><a href="games.html">Games</a></li>
            <li><a href="anime.html">Anime</a></li>
            <li><a href="english.html">Words</a></li>
            <li><a href="https://mcalawa.github.io/senior_project/">Portfolio Home</a></li>
        </ul>
       </div>
    </nav>
    
    <div class="content">
       <h2>General Information</h2>
       <p>In homework 1, you must first begin by creating a Git repository. One of the main goals is to learn Git, so you should be making multiple commits as you go along. You are also required to make a website with a unified design, an example of both single column layout and two or more column formatting, a seperate CSS file with your own classes, a navigation bar/menu with links to all of your pages, at least one table, examples of <code><span class="htmlTag">ol</span></code>, <code><span class="htmlTag">ul</span></code>, and <code><span class="htmlTag">dl</span></code>, and a page with code that summarizes your process in completing the assignment.</p>
       
       <p>The homework assignment page can be found <a href="//www.wou.edu/~morses/classes/cs46x/assignments/HW1.html">here</a> and the GitHub repository for this particular assignment can be found <a href="//github.com/mcalawa/senior_project/tree/master/CS_460_Software_Engineering/HW1">here</a>.</p>
       
       <h2>Primary Objectives</h2>
       <ol>
           <li>Learn Git: <code>init</code>, <code>add</code>, <code>commit</code>, <code>status</code>, <code>log</code>, <code>config</code>, <code>remote</code>, <code>fetch</code>, <code>pull</code>, <code>push</code></li>
           <li>Learn about remote repositories with Butbucket, GitHub, or GitLab</li>
           <li>Learn HTML</li>
           <li>Learn CSS</li>
           <li>Learn Bootstrap</li>
           <li>Demonstrate you know how to "submit" your work to the instructor</li>
           <li>Demonstrate your understanding of the Portfolio plan for the class</li>
       </ol>
       
       <h2>Overall Requirements</h2>
        <ul>
            <li>Use Git from the command line only</li>
            <li>Write (mostly) HTML 5</li>
            <li>All files are under source control and synchronized with your remote Git repository, which is public</li>
            <li>You have multiple commits on most files</li>
            <li>Cloning your repo results in a working site (prove this by cloning it to your P: drive or some other web server)</li>
            <li>You have a working GitHub Pages repository/web page meeting the requirements described below and during class</li>
            <li>Any HTML or CSS notes, cheat sheets or documentation has been put into your Portfolio in an organized fashion</li>
        </ul>
        
        <h2>Some Example Git</h2>
        <p>I was a little bit intimidated by working with Git, so after initially creating the repository, I left updating it alone for a while while I had far too much fun working with HTML, CSS, and even previewing some JavaScript. However, after I got over my early nerves, Git proved to be relatively simple. So here's how you set up and update a Git repository.</p>
        
        <code>
            git init
            git remote add origin https://github.com/mcalawa/senior_project.git
        </code>
        
        <h2>All About Lists</h2>
        <p>We were required to have at least one of each type of list. My <code><span class="htmlTag">ul</span></code> is actually my navigation with styling to remove the bullet points and made the list items appear horizontal rather than vertical.</p>
        
        <div class="htmlCode">
            <code>
                <span class="htmlTag">&lt;nav&gt;</span><br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;div</span> <span class="htmlClass">class</span>=<span class="htmlName">"navbar"</span><span class="htmlTag">&gt;</span><br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;h1&gt;</span>CS 460 Homework 1<span class="htmlTag">&lt;/h1&gt;</span><br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;ul&gt;</span><br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;li&gt;&lt;a</span> <span class="htmlClass">href</span>=<span class="htmlName">"index.html"</span> <span class="htmlClass">class</span>=<span class="htmlClass">"active"</span><span class="htmlTag">&gt;</span>Home<span class="htmlTag">&lt;/a&gt;&lt;/li&gt;</span><br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;li&gt;&lt;a</span> <span class="htmlClass">href</span>=<span class="htmlName">"games.html"</span><span class="htmlTag">&gt;</span>Games<span class="htmlTag">&lt;/a&gt;&lt;/li&gt;</span><br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;li&gt;&lt;a</span> <span class="htmlClass">href</span>=<span class="htmlName">"anime.html"</span><span class="htmlTag">&gt;</span>Anime<span class="htmlTag">&lt;/a&gt;&lt;/li&gt;</span><br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;li&gt;&lt;a</span> <span class="htmlClass">href</span>=<span class="htmlName">"english.html"</span><span class="htmlTag">&gt;</span>Words<span class="htmlTag">&lt;/a&gt;&lt;/li&gt;</span><br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;li&gt;&lt;a</span> <span class="htmlClass">href</span>=<span class="htmlName">"https://mcalawa.github.io/senior_project/"</span><span class="htmlTag">&gt;</span>Portfolio Home<span class="htmlTag">&lt;/a&gt;&lt;/li&gt;</span><br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;/ul&gt;</span><br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;<span class="htmlTag">&lt;/div&gt;</span><br/>
                &thinsp;<span class="htmlTag">&lt;/nav&gt;</span>
            </code>
        </div>
        
        <p>The nav tag marks something as navigation, while the div with the class navbar is used to apply the background color and as a wrapper to more specifically target the elements I'll be styling. The ul tag marks an unordered list and each li tag represents a list item. In this case, the list items are all links to the various pages. The main styles of note that I used for the navigation bar were <code><span class="cssElement">float</span>: <span class="cssValue">left</span>;</code>, which makes the list items float to a single line arranged from left to right, and <code><span class="cssElement">list-style</span>: <span class="cssValue">none</span>;</code>, which removes the bullet points on an unordered list. Both of these styles were applied to li tags of the class navbar.</p>
        
        <p>The ordered list is pretty similar to the unordered list. You just use an <code><span class="htmlTag">ol</span></code> instead of a <code><span class="htmlTag">ul</span></code> and it will give you a nice numbered list instead of one will bullet points. The final type of list is a definition list. I don't think definition lists were actually a thing when I first learned HTML back in the early 2000s (my Neopets days) and then more formerly in the latter half of the first decade of the 21st century. As the name would suggest, definition lists are used for defining things. Here is an example of a definition list in action.</p>
        
        <div class="htmlCode">
            <code>
                <span class="htmlTag">&lt;h2&gt;</span>Great Opening Lines<span class="htmlTag">&lt;/h2&gt;<br/>
                &thinsp;&lt;dl&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;dt&gt;&lt;em&gt;</span>Invitation to a Beheading<span class="htmlTag">&lt;em&gt;</span> by Vladimir Nabokov<span class="htmlTag">&lt;/dt&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;dd&gt;</span>In accordance with the law the death sentence was announced to Cincinnatus C. in a whisper.<span class="htmlTag">&lt;/dd&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;dt&gt;&lt;em&gt;</span>The Great Gatsby<span class="htmlTag">&lt;/em&gt;</span> by F. Scott Fitzgerald<span class="htmlTag">&lt;/dt&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;dd&gt;</span>In my younger and more vulnerable years my father game me some advice that I've been turning over in my mind ever since.<span class="htmlTag">&lt;/dd&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;dt&gt;&lt;em&gt;</span>The Voyage of the Dawn Treader<span class="htmlTag">&lt;em&gt;</span> by C.S. Lewis<span class="htmlTag">&lt;/dt&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;dd&gt;</span>There was a boy called Eustace Clarence Scrubb, and he almost deserved it.<span class="htmlTag">&lt;/dd&gt;<br/>
                &thinsp;&lt;/dl&gt;</span>
            </code>
        </div>
        
        <p>The <code><span class="htmlTag">dt</span></code> tag represents a term and the <code><span class="htmlTag">dd</span></code> tag represents that term's definition. In this example, the terms are books and their authors and the definition of a book is the opening line(s) of that particular book. </p>
        
        <h2>Tables</h2>
        <p>For my example of a table, I decided I wanted to catalogue some of the video games I own. My table ended up being fairly long, so I will only display part of it here as an example.</p>
        
        <div class="htmlCode">
            <code>
                <span class="htmlTag">&lt;table</span> <span class="htmlClass">class</span>=<span class="htmlName">"tableData"</span><span class="htmlTag">&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;thead&gt;<br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;tr&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th</span> <span class="htmlClass">onclick</span>=<span class="htmlName">"sortTableBy(0)"</span><span class="htmlTag">&gt;</span>Game<span class="htmlTag">&lt;/th&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th</span> <span class="htmlClass">onclick</span>=<span class="htmlName">"sortTableBy(1)"</span><span class="htmlTag">&gt;</span>Series<span class="htmlTag">&lt;/th&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th</span> <span class="htmlClass">onclick</span>=<span class="htmlName">"sortTableBy(2)"</span><span class="htmlTag">&gt;</span>System<span class="htmlTag">&lt;/th&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th</span> <span class="htmlClass">onclick</span>=<span class="htmlName">"sortTableBy(3)"</span><span class="htmlTag">&gt;</span>Developer<span class="htmlTag">&lt;/th&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th</span> <span class="htmlClass">onclick</span>=<span class="htmlName">"sortTableBy(4)"</span><span class="htmlTag">&gt;</span>Publisher<span class="htmlTag">&lt;/th&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th</span> <span class="htmlClass">onclick</span>=<span class="htmlName">"sortTableBy(5)"</span><span class="htmlTag">&gt;</span>Year<span class="htmlTag">&lt;/th&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;th&gt;</span>Beaten?<span class="htmlTag">&lt;/th&gt;<br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;/tr&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;/thead&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;tbody&gt;<br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;tr&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>Phoenix Wright: Ace Attorney Trilogy<span class="htmlTag">&lt;/td&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>Ace Attorney<span class="htmlTag">&lt;/td&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>Nintendo 3DS (digital)<span class="htmlTag">&lt;/td&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>Capcom<span class="htmlTag">&lt;/td&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>Capcom<span class="htmlTag">&lt;/td&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>2014<span class="htmlTag">&lt;/td&gt;<br/>
                            &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;td&gt;</span>Yes<span class="htmlTag">&lt;/td&gt;<br/>
                        &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;/tr&gt;<br/>
                    &thinsp;&thinsp;&thinsp;&thinsp;&thinsp;&lt;/tbody&gt;<br/>
                &thinsp;&lt;/table&gt;</span>
            </code>
        </div>
        
        <p>A table is wrapped in (what else but) a <code><span class="htmlTag">table</span></code> tag. Mine has a class of tableData because I wanted to be able to reorganize the data in the data by the different categories. There are then two types of content for the table (these are optional but make styling easier), the <code><span class="htmlTag">thead</span></code>, which is used for the first row of your table and holds the categories that tell you what is in each column of the table, and the <code><span class="htmlTag">tbody</span></code>, which has the actual data you are working with. Each row of the table, whether in the head or the body, is wrapped in <code><span class="htmlTag">tr</span></code> (table row) tags. Columns within a row are represented by <code><span class="htmlTag">th</span></code> (table header) tags in the head and <code><span class="htmlTag">td</span></code> (table data) tags in the body. If you choose to ommit the <code><span class="htmlTag">thead</span></code> and <code><span class="htmlTag">tbody</span></code> tags, all of the columns will use <code><span class="htmlTag">td</span></code>. As you can see, I also included some JavaScript in some of my <code><span class="htmlTag">th</span></code> tags so that I could implement a sort by the various categories. (I won't include the code I used for the sort in this write up as it's long and wasn't actually part of the assignment, but was just something that I did because I wanted to, but you can find the code in GitHub if you want to see it.)</p>
        
    </div>
		
    <!-- YOUR CONTENT ENDS HERE -->


    <!-- JavaScript: placed at the end of the document so the pages load faster -->
		<!-- jQuery library -->
        <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js" integrity="sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n" crossorigin="anonymous"></script>

        <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>

        <!-- Latest compiled and minified Bootstrap JavaScript -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js" integrity="sha384-vBWWzlZJ8ea9aCX4pEW3rVHjgjt7zpkNpZk+02D9phzyeVkE+jo0ieGizqPLForn" crossorigin="anonymous"></script>\
  </body>
</html>
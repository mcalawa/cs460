---
title: CS 460 Homework 2
layout: hw2
---
## About Homework 2

[Here](/www.wou.edu/~morses/classes/cs46x/assignments/HW2.html) is the assignment page for homework 2. The code for homework 2 can be found [here](). Basically the goal was to learn JavaScript, jQuery, and how to use HTML forms. We had to include a form that took multiple inputs, did something to modify them, and then created a table to display the results. I decided to create a calculator that measured your skill bonus at various levels for D&D 5e because I'm a big ol' nerd.

## Starting With a Design

As part of the assignment, we were supposed to design a "wireframe mockup" for our layout. Since wireframes and mockups are different things, I'm assuming what was meant was a wireframe. I decided to reuse a layout I'd made for the first homework because I tend to get very into making everything look pretty and often spend too long tinkering with CSS when I should be working on other things. One thing that is nice about web design is that if you do it right, it is always very easy to go back and change a design later once you have the content all put into place. So, without further ado, here is my wireframe design made for a layout I had already completed.

![Layout on a Large Screen](/images/wireframe_large.png)

As you can see, the layout on the page with the D&D stat calculator uses two columns, one for the form and the other for the results table. Both the form and the table are wrapped in divs and are styled with `break-inside: avoid-column;` to keep their contents from wrapping and breaking up either the form or the table. In order to better accommodate smaller screens, I've specified that there should be 2 columns with `column-count: 2;` rather than using `columns`. I've also included a `column-width`. When you have these two tags together, `column-count` will represent the maximum and ideal number of columns, but that number will decrease once the screen is no longer able to display each column at the proper column width. This is what the layout will look like when viewed on a smaller screen than is able to handle displaying both columns.

![Layout on a Small Screen](/images/wireframe_small.png)

Wireframe mockup images made with a bootstrap template created by [Matthew Stephens](/www.matthewstephens.com).

## Getting the Forms Ready for Manipulation

Since I knew I wanted to do a skill calculator for D&D 5e, I also had a good idea of what type of inputs I would need from my users. In D&D, you have six ability scores: strength (str), dexterity (dex), constitution (con), intelligence (int), wisdom (wis), and charisma (cha.) Generally these scores will be between 1 and 20, though it is possible to get higher than 20 through the use of some special items. Each ability score gives you a modifier that you then combine with dice rolls to get numbers that will decide whether you succeed or fail at various things. Ability scores are used for a wide variety of things ranging from attacks and spell casting to whether or not you are able to grab a hold of the ledge when you fall off a cliff.

In addition to these more general ability scores, there are skills that are used for more specific checks. For example, if you are trying to lie to someone, you might have to roll deception to see if they believe you and if you come across a cult and want more information on them, you might roll religion to see if you have anything you can figure out based on your knowledge of religions. Each skill has an ability score attached to it that forms part of your modifier for it. For example, athletics is attached to strength, while persuasion is attached to charisma.

In addition to the ability score element, skill modifiers are determined by something called your proficiency bonus. A proficiency bonus is decided by your level. You start with a proficiency bonus of 2 and get another point added to it every 4 levels after. A proficiency bonus can be added to your ability score modifier on a skill, but only if it is a skill you are proficient in. You can also have expertise in a skill, meaning you add double your proficiency bonus to the ability score modifer. There are other things that can affect what bonus you have on a skill roll, but the simple formula for figuring out a skill bonus is $$ability score modifier + (proficiency bonus * your proficiency)$$.

Therefore, I decided to use number inputs for the ability scores (I included all 6 of them even though constitution doesn't affect any skills because your character sheet has all 6 and constitution is in the middle, making it too easy to input the wrong numbers without the sheet) and that each skill would have a set of three radio buttons ("No Modifiers", "Proficient", and "Expertise") that each had a value of what your proficiency bonus would be multiplied by (0, 1, and 2 respectively.) Here is an abreviated version of the code for the form.

```html
 <form id="dndForm">
    <div class="leftHalf">
        <div class="formHeader"><h2>Calculate Your Skill Modifers by Level</h2></div><br/><br/>
        Strength <input type="number" name="str" id="str"><br/>
        Dexterity <input type="number" name="dex" id="dex"><br/>
        Constitution <input type="number" name="con" id="con"><br/>
        Intelligence <input type="number" name="int" id="int"><br/>
        Wisdom <input type="number" name="wis" id="wis"><br/>
        Charisma <input type="number" name="cha" id="cha"><br/>
               <br/>
               
        <span id="entryError"></span>
               
        <span class="radioPro">Acrobatics 
        <input type="radio" name="skill0" value="0" checked="checked"> No Modifiers 
        <input type="radio" name="skill0" value="1"> Proficient 
        <input type="radio" name="skill0" value="2"> Expertise</span><br/>
        
        <div class="formSubmit"><input type="submit"></div>
    </div>
</form>
```

The form has an id so that it can be easily called in Javascript. The surrounding `div`, leftHalf, is used to wrap all of the contents because I wanted to put the form and its output in two different columns and I didn't want the form to get cut in half to fit in the two columns prior to the results being output. To accomplish this, I used the CSS `{break-inside: avoid-column;}` to keep it all in a single column. 

As you can see, the `input` types I used were `number`, `radio`, and `submit`. The `number` inputs have both a `name` and an `id` for identification purposes, while the `radio` inputs have a `name` for identification purposes (and to mark them as a group) and a `value` that functions as the multiplier for your proficiency bonus. Additionally, I made the radio button that indicated you weren't proficient in a skill prechecked so that there was one less thing that needed error checking.

Speaking of error checking, I also have a span for outputting an error message should the user not give a valid input or fail to input anything for their ability scores. The submit button finishes out the form by allowing you to submit your information to be calculated. After the form, I needed a place where my processed information would be output, so I created a simple `div` with an `id` so that it could be easily accessed by the Javascript.

## Javascript to Modify the Form Data

Deciding what Javascript you should use means that you first need to decide what your output is going to look like. I knew I was going to want one column for the skill name and then another column for levels 1-4 (the levels before your proficiency bonus increases for the first time) and then another column for each 4 levels after that. Once I had decided that, I started with creating a few constants. 

```javascript
const skillName = ["Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "Slight of Hand", "Stealth", "Survival"];
//the name of each skill so I can for loop my output instead of having to write it manually

const skillAbility = [1, 3, 2, 0, 4, 2, 3, 4, 2, 3, 2, 3, 4, 4, 4, 2, 1, 1, 3]; //the array index of the ability score modifier that affects each skill
//I didn't include constitution in the array because it doesn't modify any skills so 0 = str, 1 = dex, 2 = int, 3 = wis, 4 = cha

const proBonus = [0, 2, 3, 4, 5, 6]; //proficiency bonus for each of the sets of 4 levels I am recording
/*there is no proficiency bonus of 0, but it's included because the first column has a skill name rather than a skill modifier and I wanted the array indexes to match so I didn't need another variable*/
```

The next thing I had to do was create a function to take in all of the data from the form submission, check it for errors and return and print an error message if there are any, put the data into a form that it could be used, and call any other functions that might need to be run to calculate the data.

```javascript
//a function to collect the data, error check it, and put it in a form I can use to do calculations
//called when submit is clicked
$("#dndForm").submit(function (event) {
    event.preventDefault();
    var score = new Array(5); /*an array of the raw ability scores
    minus constitution since that isn't actually used for any skills*/
    var abilityMod = new Array(5); //an array of the ability score modifiers
    var proMultiplier = new Array(18); //what the proficiency bonus will be multipled by for each skill
    //0 represents a skill you aren't proficient in, 1 is a skill you are proficient in, and 2 is a skill with expertise
    
    //Getting all the ability scores from the form data
    score[0] = $("#str").val();
    score[1] = $("#dex").val();
    score[2] = $("#int").val();
    score[3] = $("#wis").val();
    score[4] = $("#cha").val();
    
    //check input validity and get ability score modifiers
    for(var i = 0; i < 5; i++) { //for each ability score
        if(score[i] < 1 || score[i] > 30) { //if it's invalid
            console.log("Invalid ability score of " + score[i]); //write an error message to the console
            $("#resultsTable").empty(); //remove anything currently in the place where we're putting the table
            $("#entryError").html("Please enter valid Ability Scores of between 1 and 30.") //write an error message on the page
            return; //and then get out of there
        }
        else { //if the ability score is valid
            abilityMod[i] = getStatMod(score[i]); //assign the modifier for that ability score to the matching array index
        }
    } //if you get here, everything is valid
    
    for(i = 0; i < 18; i++) { //for each of the skills
        
        proMultiplier[i] = $('input[name="skill' + i + '"]:checked').val(); //assign the value of whichever radio button was checked
        //I purposefully named the skills skill0-skill17 so that I could for loop it
    } //we have all the form data we needed!
    
    //write a message to the console letting them know its a success
    console.log("Generating skill table"); 
    $("#resultsTable").empty(); //remove any previous result table
    //put the skill table code that was generated by another function in the div I created to display the output
    $("#resultsTable").append(skillTable(abilityMod, proMultiplier));
    //overwrite any previous error messages that might have been written
    $("#entryError").html("");
});
```

As you can see, this function calls a couple of other functions. The function used to turn ability scores into ability score modifiers, getStatMod, is very simple with just a large if/if else/else statement, so I won't be showing it. Instead I will share the function I create and return a table to display the calculated data with, skillTable.

```javascript
//creates a table to output the data in an organized fashion
//based partially on the example Javascript written by Scot Morse
//abilityMod is an array of modifiers for the ability scores
//proMultiplier is an array of proficiency bonus multipliers for each skill
function skillTable(abilityMod, proMultiplier) {
    "use strict";
    var tab = $("<table>"); //the inital table tag and what the rest of the code attaches to
    var thead = $("<thead>\
                        <tr>\
                            <th>Skill</th>\
                            <th>Level 1-4</th>\
                            <th>Level 5-8</th>\
                            <th>Level 9-12</th>\
                            <th>Level 13-16</th>\
                            <th>Level 17-20</th>\
                        </tr>\
                    </thead>"); /*the thead with a row that has
                    columns for the skill name and each of the level
                    ranges with different proficiency bonuses*/
    thead.appendTo(tab); //attach the thead to the table
    
    var tbody = $("<tbody>"); //create a tbody
    var trow = null; //for holding each row; null since it will be assigned later
    var tdat = null; //for each td in a table row; null since it will be assigned later
    var n = null; //where the actual calculated data goes; null since it will be assigned later
    for(var ir = 0; ir < 18; ir++) { //for each of the 18 rows in the tbody
        trow = $("<tr>"); //create the row
        for(var ic = 0; ic < 6; ic++) { //for each of the 6 columns
            if(ic === 0) { //if it's the first column (with the skill names)
                n = skillName[ir]; //the data will be the skill name for that row
            }
            else { //if it is for any of the other columns
                /*the data is the ability score modifier for the 
                ability score that affects the skill in that row
                plus the multiplier for the proficiency bonus of the 
                skill in that row times the proficiency bonus for 
                that column (or level range, since that's what the
                columns after the first one represent'*/
                n = abilityMod[skillAbility[ir]] + (proMultiplier[ir] * proBonus[ic]);
            } //either way, the data will be assigned to n by this point
            
            //create a pair of td tags with the data in the middle
            tdat = $("<td>").html(n); 
            tdat.appendTo(trow); //attach it to the row
        } //repeat this until that row is complete
        trow.appendTo(tbody); //attach the row to the tbody
    } //repeat this until all the rows are done
    tbody.appendTo(tab); //attach all of this to the other code for the table
    //The tags will all close themselves when processed, so we don't need to add closing tags
    return tab; //return the table we created so it can be posted
}
```

And that is a working stat calculator for your D&D skill modifiers! As I said, there are other things that can affect skill modifiers, so if I had more time I could make this much more complicated, but this is the simple version that matches the assignment criteria of "not too complicated."
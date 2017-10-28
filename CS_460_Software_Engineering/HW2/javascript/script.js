const skillName = ["Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "Slight of Hand", "Stealth", "Survival"];
//the name of each skill so I can for loop my output instead of having to write it manually

const skillAbility = [1, 3, 2, 0, 4, 2, 3, 4, 2, 3, 2, 3, 4, 4, 4, 2, 1, 1, 3]; //the array index of the ability score modifier that affects each skill
//I didn't include constitution in the array because it doesn't modify any skills so 0 = str, 1 = dex, 2 = int, 3 = wis, 4 = cha

const proBonus = [0, 2, 3, 4, 5, 6]; //proficiency bonus for each of the sets of 4 levels I am recording
/*there is no proficiency bonus of 0, but it's included because the first column has a skill name rather than a skill modifier and I wanted the array indexes to match so I didn't need another variable*/


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
} //function skillTable

//takes in an ability score and returns the correct modifier for that score
function getStatMod(stat) {
    var mod = Number; //sets the type of the variable
    
    if(stat == 1) {
        mod = -5;
    }
    else if(stat < 4) { //2-3
        mod = -4;
    }
    else if(stat < 6) { //4-5
        mod = -3;
    }
    else if(stat < 8) { //6-7
        mod = -2;
    }
    else if(stat < 10) { //8-9
        mod = -1;
    }
    else if(stat < 12) { //10-11
        mod = 0;
    }
    else if(stat < 14) { //12-13
        mod = 1;
    }
    else if(stat < 16) { //14-15
        mod = 2;
    }
    else if(stat < 18) { //16-17
        mod = 3;
    }
    else if(stat < 20) { //18-19
        mod = 4;
    }
    else if(stat < 22) { //20-21
        mod = 5;
    }
    else if(stat < 24) { //22-23
        mod = 6;
    }
    else if(stat < 26) { //24-25
        mod = 7;
    }
    else if(stat < 28) { //26-27
        mod = 8;
    }
    else if(stat < 30) { //28-29
        mod = 9;
    }
    else { //30 because this function is not called if it's more than 30 or less than 1
        mod = 10;
    }
    
    return mod;
} //function getStatMod

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
}); //submit
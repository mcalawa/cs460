const skillName = ["Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "Slight of Hand", "Stealth", "Survival"];

const skillAbility = [1, 3, 2, 0, 4, 2, 3, 4, 2, 3, 2, 3, 4, 4, 4, 2, 1, 1, 3];

const proBonus = [0, 2, 3, 4, 5, 6];

function skillTable(abilityMod, proMultiplier) {
    "use strict";
    var tab = $("<table>");
    var thead = $("<thead>\
                        <tr>\
                            <th>Skill</th>\
                            <th>Level 1-4</th>\
                            <th>Level 5-8</th>\
                            <th>Level 9-12</th>\
                            <th>Level 13-16</th>\
                            <th>Level 17-20</th>\
                        </tr>\
                    </thead>");
    thead.appendTo(tab);
    
    var tbody = $("<tbody>");
    var trow = null;
    var tdat = null;
    var n = null;
    for(var ir = 0; ir < 18; ir++) {
        trow = $("<tr>");
        for(var ic = 0; ic < 6; ic++) {
            if(ic === 0) {
                n = skillName[ir];
            }
            else {
                n = abilityMod[skillAbility[ir]] + (proMultiplier[ir] * proBonus[ic]);
            }
            
            tdat = $("<td>").html(n);
            tdat.appendTo(trow);
        }
        trow.appendTo(tbody);
    }
    tbody.appendTo(tab);
    return tab;
}

function getStatMod(stat) {
    var mod = Number;
    
    if(stat == 1) {
        mod = -5;
    }
    else if(stat < 4) {
        mod = -4;
    }
    else if(stat < 6) {
        mod = -3;
    }
    else if(stat < 8) {
        mod = -2;
    }
    else if(stat < 10) {
        mod = -1;
    }
    else if(stat < 12) {
        mod = 0;
    }
    else if(stat < 14) {
        mod = 1;
    }
    else if(stat < 16) {
        mod = 2;
    }
    else if(stat < 18) {
        mod = 3;
    }
    else if(stat < 20) {
        mod = 4;
    }
    else if(stat < 22) {
        mod = 5;
    }
    else if(stat < 24) {
        mod = 6;
    }
    else if(stat < 26) {
        mod = 7;
    }
    else if(stat < 28) {
        mod = 8;
    }
    else if(stat < 30) {
        mod = 9;
    }
    else {
        mod = 10;
    }
    
    return mod;
}

$("#dndForm").submit(function (event) {
    event.preventDefault();
    var score = new Array(5);
    var abilityMod = new Array(5);
    var proMultiplier = new Array(18);
    
    score[0] = $("#str").val();
    score[1] = $("#dex").val();
    score[2] = $("#int").val();
    score[3] = $("#wis").val();
    score[4] = $("#cha").val();
    
    for(var i = 0; i < 5; i++) {
        if(score[i] < 1 || score[i] > 30) {
            console.log("Invalid ability score of " + score[i]);
            $("#resultsTable").empty();
            $("#entryError").html("Please enter valid Ability Scores of between 1 and 30.")
            return;
        }
        else {
            abilityMod[i] = getStatMod(score[i]);
        }
    }
    
    for(i = 0; i < 18; i++) {
        
        proMultiplier[i] = $('input[name="skill' + i + '"]:checked').val();
    }
    
    console.log("Generating skill table");
    $("#resultsTable").empty();
    $("#resultsTable").append(skillTable(abilityMod, proMultiplier));
    $("#entryError").html("");
});
function createTable(statMod, proBonus, modifier, skillName, skillMod) {
    "use strict";
    var tab = $("<table>");
    var thead = $("<thead>\
                        <tr>\
                            <th>Skill</th>\
                            <th>Level 1-4</th>\
                            <th>Level 5-8</th>\
                            <th>Level 9-12</th>\
                            <th>Level 13-16</th>\
                            <th>Level 17+</th>\
                        </tr>\
                    </thead>");
    
    thead.appendTo(tab);
    
    var tbody = $("<tbody>");
    var trow = null;
    var tdat = null;
    var data = null;
    for(var i = 0; i < modifier.length; i++) {
        trow = $("<tr>");
        for(var j = 0; j < 6; j++) {
            tdat = $("<td>")
            if(j == 0) {
                data = skillName[i];
            }
            else {
                var k = skillMod[i];
                data = statMod[k] + (proBonus[j] * modifier);
            }
            
            data.appendTo(tdat);
            tdat.appendTo(trow);
            tdat = $("</td>");
            tdat.appendTo(trow);
        }
        trow.appendTo(tbody);
        trow = $("</tr>");
        trow.appendTo(tbody);
    }
    tbody.appendTo(tab);
    tbody = $("</tbody></table>")
    tbody.appendTo(tab);
    
    return tab;
}

$("#dndForm").submit(function () {
    var stats = new Array(5);
    var statMod = new Array(5);
    var proBonus = new Array(5);
    var modifier = new Array(1);
    var skillName = new Array(1);
    var skillMod = new Array(1);
    
    stats[0] = $("#str").valueOf; 
    stats[1] = $("#dex").valueOf;
    stats[2] = $("#int").valueOf;
    stats[3] = $("#wis").valueOf;
    stats[4] = $("#cha").valueOf;
    
    for(var i = 0; i < 5; i++) {
        if(stats[i] < 2) {
            statMod[i] = -5;
        }
        else if(stats[i] < 4) {
            statMod[i] = -4;
        }
        else if(stats[i] < 6) {
            statMod[i] = -3;
        }
        else if(stats[i] < 8) {
            statMod[i] = -2;
        }
        else if(stats[i] < 10) {
            statMod[i] = -1;
        }
        else if(stats[i] < 12) {
            statMod[i] = 0;
        }
        else if(stats[i] < 14) {
            statMod[i] = 1;
        }
        else if(stats[i] < 16) {
            statMod[i] = 2;
        }
        else if(stats[i] < 18) {
            statMod[i] = 3;
        }
        else if(stats[i] < 20) {
            statMod[i] = 4;
        }
        else {
            statMod[i] = 5;
        }
    }
    
    for(var j = 0; i < 5; i++) {
        proBonus[j] = j + 2;
    }
        
    modifier[0] = $('input[name="acrobatics"]:checked').valueOf;
    skillName[0] = "Acrobatics";
    skillMod[0] = 1;
    
    $("#resultsTable").empty();
    $("#resultsTable").append(createTable(statMod, proBonus, modifier, skillName, skillMod));
});
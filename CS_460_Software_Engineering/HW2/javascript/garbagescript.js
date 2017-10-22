
function calcStats() 
{
    var outputTable, rows, hData, tData; 
    var strMod, dexMod, intMod, wisMod, chaMod;
    var strength = window.document.forms["dndForm"]["str"].value;
    var dexterity = window.document.forms["dndForm"]["dex"].value;
    var intellegence = window.document.forms["dndForm"]["int"].value;
    var wisdom = window.document.forms["dndForm"]["wis"].value;
    var charisma = window.document.forms["dndForm"]["cha"].value;
    var className = window.document.forms["dndForm"]["class"].value;
    var multiplier, item, bonus;
    
    if(strength < 2) {
        strMod = -5;
    }
    else if(strength < 4) {
        strMod = -4;
    }
    else if(strength < 6) {
        strMod = -3;
    }
    else if(strength < 8) {
        strMod = -2;
    }
    else if(strength < 10) {
        strMod = -1;
    }
    else if(strength < 12) {
        strMod = 0;
    }
    else if(strength < 14) {
        strMod = 1;
    }
    else if(strength < 16) {
        strMod = 2;
    }
    else if(strength < 18) {
        strMod = 3;
    }
    else if(strength < 20) {
        strMod = 4;
    }
    else {
        strMod = 5;
    }
    
    
    
    if(dexterity < 2) {
        dexMod = -5;
    }
    else if(dexterity < 4) {
        dexMod = -4;
    }
    else if(dexterity < 6) {
        dexMod = -3;
    }
    else if(dexterity < 8) {
        dexMod = -2;
    }
    else if(dexterity < 10) {
        dexMod = -1;
    }
    else if(dexterity < 12) {
        dexMod = 0;
    }
    else if(dexterity < 14) {
        dexMod = 1;
    }
    else if(dexterity < 16) {
        dexMod = 2;
    }
    else if(dexterity < 18) {
        dexMod = 3;
    }
    else if(dexterity < 20) {
        dexMod = 4;
    }
    else {
        dexMod = 5;
    }
    
    
    if(intellegence < 2) {
        intMod = -5;
    }
    else if(intellegence < 4) {
        intMod = -4;
    }
    else if(intellegence < 6) {
        intMod = -3;
    }
    else if(intellegence < 8) {
        intMod = -2;
    }
    else if(intellegence < 10) {
        intMod = -1;
    }
    else if(intellegence < 12) {
        intMod = 0;
    }
    else if(intellegence < 14) {
        intMod = 1;
    }
    else if(intellegence < 16) {
        intMod = 2;
    }
    else if(intellegence < 18) {
        intMod = 3;
    }
    else if(intellegence < 20) {
        intMod = 4;
    }
    else {
        intMod = 5;
    }
    
    
    
    if(wisdom < 2) {
        wisMod = -5;
    }
    else if(wisdom < 4) {
        wisMod = -4;
    }
    else if(wisdom < 6) {
        wisMod = -3;
    }
    else if(wisdom < 8) {
        wisMod = -2;
    }
    else if(wisdom < 10) {
        wisMod = -1;
    }
    else if(wisdom < 12) {
        wisMod = 0;
    }
    else if(wisdom < 14) {
        wisMod = 1;
    }
    else if(wisdom < 16) {
        wisMod = 2;
    }
    else if(wisdom < 18) {
        wisMod = 3;
    }
    else if(wisdom < 20) {
        wisMod = 4;
    }
    else {
        wisMod = 5;
    }
    
    
    
    
    if(charisma < 2) {
        chaMod = -5;
    }
    else if(charisma < 4) {
        chaMod = -4;
    }
    else if(charisma < 6) {
        chaMod = -3;
    }
    else if(charisma < 8) {
        chaMod = -2;
    }
    else if(charisma < 10) {
        chaMod = -1;
    }
    else if(charisma < 12) {
        chaMod = 0;
    }
    else if(charisma < 14) {
        chaMod = 1;
    }
    else if(charisma < 16) {
        chaMod = 2;
    }
    else if(charisma < 18) {
        chaMod = 3;
    }
    else if(strength < 20) {
        chaMod = 4;
    }
    else {
        chaMod = 5;
    }
    
    outputTable = window.document.getElementById("dndResults");
    rows = outputTable.getElementsByTagName("tr");
    hData = rows[0].getElementsByTagName("th");
    
    hData[0].innerHTML = "Skills";
    hData[1].innerHTML = "Level 1";
    hData[2].innerHTML = "Level 2-4";
    hData[3].innerHTML = "Level 5-8";
    hData[4].innerHTML = "Level 9-12";
    hData[5].innerHTML = "Level 13-16";
    hData[6].innerHTML = "Level 17+";
    
    tData = rows[1].getElementsByTagName("td");
    
    multiplier = window.document.forms["dndForm"]["acrobatics"].value;
    bonus = window.document.forms["dndForm"]["acrobaticsBonus"].value;
    tData[0].innerHTML = "Acrobatics";
    if(className == "jack" && multiplier == 0) {
        if(window.document.getElementById("acrobaticsItem").checked) {
            tData[1].innerHTML = dexMod + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[2].innerHTML = dexMod + 1 + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[3].innerHTML = dexMod + 1 + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[4].innerHTML = dexMod + 2 + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[5].innerHTML = dexMod + 2 + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[6].innerHTML = dexMod + 3 + window.document.forms["dndForm"]["acrobaticsBonus"].value;
        }
        else {
            tData[1].innerHTML = dexMod;
            tData[2].innerHTML = dexMod + 1;
            tData[3].innerHTML = dexMod + 1;
            tData[4].innerHTML = dexMod + 2;
            tData[5].innerHTML = dexMod + 2;
            tData[6].innerHTML = dexMod + 3;
        }
    }
    else {
        if(window.document.getElementById("acrobaticsItem").checked) {
            tData[1].innerHTML = dexMod + (2 * bonus) + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[2].innerHTML = dexMod + (2 * bonus) + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[3].innerHTML = dexMod + (3 * bonus) + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[4].innerHTML = dexMod + (4 * bonus) + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[5].innerHTML = dexMod + (5 * bonus) + window.document.forms["dndForm"]["acrobaticsBonus"].value;
            tData[6].innerHTML = dexMod + (6 * bonus) + window.document.forms["dndForm"]["acrobaticsBonus"].value;
        }
        else {
            tData[1].innerHTML = dexMod + (2 * bonus);
            tData[2].innerHTML = dexMod + (2 * bonus);
            tData[3].innerHTML = dexMod + (3 * bonus);
            tData[4].innerHTML = dexMod + (4 * bonus);
            tData[5].innerHTML = dexMod + (5 * bonus);
            tData[6].innerHTML = dexMod + (6 * bonus);
        }
    }
    
    tData = rows[2].getElementsByTagName("td");
    tData = rows[3].getElementsByTagName("td");
    tData = rows[4].getElementsByTagName("td");
    tData = rows[5].getElementsByTagName("td");
    tData = rows[6].getElementsByTagName("td");
    tData = rows[7].getElementsByTagName("td");
    tData = rows[8].getElementsByTagName("td");
    tData = rows[9].getElementsByTagName("td");
    tData = rows[10].getElementsByTagName("td");
    tData = rows[11].getElementsByTagName("td");
    tData = rows[12].getElementsByTagName("td");
    tData = rows[13].getElementsByTagName("td");
    tData = rows[14].getElementsByTagName("td");
    tData = rows[15].getElementsByTagName("td");
    tData = rows[16].getElementsByTagName("td");
    tData = rows[17].getElementsByTagName("td");
}
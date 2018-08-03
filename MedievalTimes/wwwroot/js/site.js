
window.onload = Initieer;

//**************************************************************************************************************************************************************** VARIABLES ***

// max reroll possibilities when creating character
var reroll = 60;

//Init Attribute variables
var strength = rollDice(3, 6, 0);
var dexterity = rollDice(3, 6, 0);
var constitution = rollDice(3, 6, 0);
var intelligence = rollDice(3, 6, 0);
var wisdom = rollDice(3, 6, 0);
var charisma = rollDice(3, 6, 0);

//****************************************************************************************************************************************************************** METHODS ***

//Init Function
function Initieer() {
    $("#rollAttributes").click(ReRoll);
    SetDefaultAttributes();
}

// This function will set the values for the attributes, when creating a character
function SetDefaultAttributes() {
    $("#strAttribute").val(strength);
    $("#dexAttribute").val(dexterity);
    $("#conAttribute").val(constitution);
    $("#intAttribute").val(intelligence);
    $("#wisAttribute").val(wisdom);
    $("#chaAttribute").val(charisma);
}

// This function rolls dices and returns the total value. 
// Example 3d6 + 2, 3 dices, 6 sided, +2 modifier at the end
function rollDice(nrDice, DiceSide, Modifier) {
    var totalPoints = 0;
    for (var teller = 0; teller < nrDice; teller++)
        totalPoints += Math.floor(Math.random() * DiceSide) + 1;
    totalPoints += Modifier;
    return totalPoints;
}

//This function rerolls the attributes for character creation, but not more than default times.
function ReRoll() {
    if (reroll <= 0) {
        alert("Their are no new rolls possible.");
    }
    else {
        strength = rollDice(3, 6, 0);
        dexterity = rollDice(3, 6, 0);
        constitution = rollDice(3, 6, 0);
        intelligence = rollDice(3, 6, 0);
        wisdom = rollDice(3, 6, 0);
        charisma = rollDice(3, 6, 0);

        SetDefaultAttributes();

        reroll--;

        $("#rollAttributes").text("ReRoll Dices (" + reroll + ")");
    }
}


function ChooseWPs(initFreeWPs, id) {

    freeWPs = $('#FreeWeaponProficiencies').value;

    if (isNaN('freeWPs')) {
        freeWPs = document.getElementById('FreeWeaponProficiencies').value;
    }

    if (freeWPs <= 0) {
        alert("You don't have any free weapon proficiency slots to spend!");
        document.getElementById(id).value--;
    }
    else {
        freeWPs = freeWPs-1;
    }

    document.getElementById('FreeWeaponProficiencies').value = freeWPs;

}
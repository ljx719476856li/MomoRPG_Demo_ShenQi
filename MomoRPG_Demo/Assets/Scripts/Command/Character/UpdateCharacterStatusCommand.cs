using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCharacterStatusCommand :EventCommand
{
    [Inject]
    public ParseCharacterJson parseCharacterJson { get; set; }


    public override void Execute()
    {
        parseCharacterJson.ParseModelJson();
        dispatcher.Dispatch(CharacterMediatorEvent.GetCharacterData, parseCharacterJson.CharacterModelList);
        dispatcher.Dispatch(CharacterMediatorEvent.CharacterLevelUp);
    }


    private void OnLevelUp()
    {

    }
} 

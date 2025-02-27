using UnityEngine;

public class ValidatedRoom : Room
{
    public bool hasUpExit;
    public bool hasDownExit;
    public bool hasLeftExit;
    public bool hasRightExit;

    public bool hasUpDownPath;
    public bool hasUpLeftPath;
    public bool hasUpRightPath;
    public bool hasDownLeftPath;
    public bool hasDownRightPath;
    public bool hasLeftRightPath;

    public bool meetsConstraint(ExitConstraint requiredExits)
    {
        if (requiredExits.upExitRequired && hasUpExit == false)
            return false;
        
        if (requiredExits.downExitRequired && hasDownExit == false)
            return false;
        
        if (requiredExits.rightExitRequired && hasRightExit == false)
            return false;
        
        if (requiredExits.leftExitRequired && hasLeftExit == false)
            return false;

        if (requiredExits.upExitRequired && requiredExits.downExitRequired && hasUpDownPath == false)
            return false;
        
        if (requiredExits.upExitRequired && requiredExits.leftExitRequired && hasUpLeftPath == false)
            return false;
        
        if (requiredExits.upExitRequired && requiredExits.rightExitRequired && hasUpRightPath == false)
            return false;
        
        if (requiredExits.downExitRequired && requiredExits.leftExitRequired && hasDownLeftPath == false)
            return false;
        
        if (requiredExits.downExitRequired && requiredExits.rightExitRequired && hasDownRightPath == false)
            return false;
        
        if (requiredExits.leftExitRequired && requiredExits.rightExitRequired && hasLeftRightPath == false)
            return false;
        
        return true;
    }
}

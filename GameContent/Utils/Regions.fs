﻿namespace Regions 

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input

module GeometricFunctions = 
    let IsBetweenLimits (mousePoint: int, inferiorLimit: int, superiorLimit: int) : bool =
        if mousePoint >= inferiorLimit && mousePoint <= superiorLimit then
            true
        else
            false

    let IsInReagion (mouse: Point, rect: Microsoft.Xna.Framework.Rectangle) : bool =
        IsBetweenLimits(mouse.X, rect.Left, rect.Right) && IsBetweenLimits(mouse.Y, rect.Top, rect.Bottom)

module Interactive = 
    let HasMouseClickedRegion (actualState: MouseState, prevState: MouseState, rect: Rectangle) : bool =
        if GeometricFunctions.IsInReagion(actualState.Position, rect) 
            && Handlers.Input.IsMouseClick(actualState, prevState) then
            true
        else
            false

module State =
    let GetStateString (state) : string =
        if state = 1 then
            "X"
        elif state = -1 then
            "O" 
        else
            ""
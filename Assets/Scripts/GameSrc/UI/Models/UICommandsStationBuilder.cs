using Game;
using MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICommandsStationBuilder
{
    private GameMainPanelView view;
    private IBlockTypeProvider provider;
    private CellActionUpdater actionUpdater;

    private Cell firstClicledCell;
    private Cell SecondClicledCell;

    private enum State
    {
        WaitPlayerInput,
        PlayerClickAttackButton,
    }
    private State state;
    public UICommandsStationBuilder(GameMainPanelView mainPanelView, IBlockTypeProvider blockTypeProvider,CellActionUpdater cellActionUpdater,CellPool cellPool)
    {
        view = mainPanelView;
        provider = blockTypeProvider;
        actionUpdater = cellActionUpdater;
        state = State.WaitPlayerInput;

        cellPool.CellClicked += StationClicked;

        mainPanelView.SetActiveAddArmyButton(false);
        mainPanelView.SetActiveAttackButton(false);
    }

    public void StationClicked(Cell cell)
    {
        if (provider.GetBlockTypeInPosition(cell.x, cell.y) == BlockType.Staion)
        {
            switch (state)
            {
                case State.WaitPlayerInput:
                    {
                        firstClicledCell = cell;
                        view.SetActiveAttackButton(true);
                        view.AddHandlerBtnAttack(AttackHandler);
                        break;
                    }
                case State.PlayerClickAttackButton:
                    {
                        SecondClicledCell = cell;
                        view.SetActiveAttackButton(false);
                        view.RemoveHandlerBtnAttack(AttackHandler);
                        actionUpdater.AddAction(new CActionMoveArmy(firstClicledCell, SecondClicledCell, 10));
                        state = State.WaitPlayerInput;
                        break;
                    }
            }
        }

    }

    private void AttackHandler()
    {
        state = State.PlayerClickAttackButton;
    }


}

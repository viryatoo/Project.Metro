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
    private MapUtility utility;
    private Cell firstClicledCell;
    private Cell SecondClicledCell;

    private enum State
    {
        PlayerClickedStation,
        PlayerClickAttackButton,
        PlayerWaitInput
    }
    private State state;
    public UICommandsStationBuilder(GameMainPanelView mainPanelView, IBlockTypeProvider blockTypeProvider,CellActionUpdater cellActionUpdater,CellPool cellPool,MapUtility mapUtility)
    {
        view = mainPanelView;
        provider = blockTypeProvider;
        actionUpdater = cellActionUpdater;
        state = State.PlayerClickedStation;
        utility = mapUtility;

        cellPool.CellClicked += StationClicked;

        mainPanelView.SetActiveAddArmyButton(false);
        mainPanelView.SetActiveAttackButton(false);
    }

    public void StationClicked(Cell cell)
    {
        Debug.Log(cell.x);
        Debug.Log(cell.y);
        if (provider.GetBlockTypeInPosition(cell.x, cell.y) == BlockType.Staion)
        {
            Debug.Log("SFFF");
            switch (state)
            {
                case State.PlayerClickedStation:
                    {
                        firstClicledCell = cell;
                        view.SetActiveAttackButton(true);
                        view.AddHandlerBtnAttack(AttackHandler);
                        break;
                    }
                case State.PlayerClickAttackButton:
                    {
                        SecondClicledCell = cell;

                        view.RemoveHandlerBtnAttack(AttackHandler);
                        view.SetActiveAttackButton(false);

                        int distance = utility.CalculateDistance(new Vector2Int(firstClicledCell.x, firstClicledCell.y), new Vector2Int(SecondClicledCell.x, SecondClicledCell.y));
                        actionUpdater.AddAction(new CActionMoveArmy(firstClicledCell, SecondClicledCell, distance));
                        state = State.PlayerClickedStation;
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

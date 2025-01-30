using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    public float ProductivityMultiplier = 2;
    private ResourcePile m_currentPile = null;

    protected override void BuildingInRange()
    {
        if(m_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null)
            {
                m_currentPile = pile;
                m_currentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivy()
    {
        if(m_currentPile != null)
        {
            m_currentPile.ProductionSpeed /= ProductivityMultiplier;
            m_currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivy();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivy();
        base.GoTo(position);
    }
}

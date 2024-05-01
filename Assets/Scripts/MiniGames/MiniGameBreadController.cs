using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBreadController : AMiniGameController
{
    #region Singleton
    private static MiniGameBreadController m_Instance;
    public static MiniGameBreadController Instance { get { return m_Instance; } }
    #endregion

    public MiniGameBreadController() : base(EItem.Bread)
    {
    }

    private void Awake()
    {
        if (m_Instance != null)
            Destroy(gameObject);

        m_Instance = this;
    }

    public override void Execute()
    {
        base.Execute();
    }
}

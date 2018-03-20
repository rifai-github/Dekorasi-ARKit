using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModal : MonoBehaviour
{
    public GameObject _ModalPanel;

    protected bool _bIsOpenModal;

    public virtual void OpenModal()
    {
        _ModalPanel.SetActive(true);
        _bIsOpenModal = true;
    }

    public virtual void CloseModal()
    {
        _bIsOpenModal = false;
        _ModalPanel.SetActive(false);
    }
}

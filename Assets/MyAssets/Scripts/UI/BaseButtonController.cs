using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseButtonController : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private BaseButtonController sceneButtonController;
    [SerializeField] private SceneButtonType.ButtonType buttonType;
    private BaseButtonController[] buttonControllers;

    private bool isPushed = false;
    
    void Awake()
    {
        Transform canvas = GameObject.Find("Canvas").transform;
        buttonControllers = canvas.GetComponentsInChildren<BaseButtonController>();
    }
    
    void OnEnable()
    {
        ButtonActive(true);
    }

    public void ButtonActive(bool active)
    {
        isPushed = !active;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPushed) return;
        OnButtonDown(this.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPushed) return;
        OnButtonUp(this.gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPushed) return;
        if (buttonType != SceneButtonType.ButtonType.PosshibleMash)
        {
            foreach (var controller in buttonControllers)
            {
                controller.ButtonActive(controller.buttonType != this.buttonType);
            }
        }
        
        OnButtonClick(this.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    } 
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void AllButtonReset()
    {
        foreach (var controller in buttonControllers)
        {
            controller.ButtonActive(true);
        }
    }

    protected virtual void OnButtonDown(string objName)
    {
        if (sceneButtonController == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        sceneButtonController.OnButtonDown(objName);
    }

    protected virtual void OnButtonUp(string objName)
    {
        if (sceneButtonController == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        sceneButtonController.OnButtonUp(objName);
    }

    protected virtual void OnButtonClick(string objName)
    {
        if (sceneButtonController == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        sceneButtonController.OnButtonClick(objName);
    }
}

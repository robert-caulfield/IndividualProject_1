using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : BaseInteractivePuzzlePiece
{
    Renderer r;
    Collider c;
    public bool off_by_default = true;
    Color active_color, inactive_color;
    protected override void ApplyActiveState()
    {
        r.material.SetColor("_Color", off_by_default ? active_color : inactive_color);
        c.enabled = off_by_default;
    }

    protected override void ApplyInactiveState()
    {
        r.material.SetColor("_Color", !off_by_default ? active_color : inactive_color);
        c.enabled = !off_by_default;
    }

    // Start is called before the first frame update
    void Start()
    {
        print("In here!");
        r = GetComponent<Renderer>();
        Material material = r.material;

        material.SetOverrideTag("RenderType", "Transparent");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        active_color = inactive_color = r.material.color;
        inactive_color = new Color(r.material.color.r/2, r.material.color.g, 1.0f,.1f);
        r.material.SetColor("_Color", off_by_default ? inactive_color : active_color);


        c = GetComponent<Collider>();
        c.enabled = !off_by_default;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

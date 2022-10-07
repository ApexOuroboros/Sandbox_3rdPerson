using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPerspective : MonoBehaviour
{

    public enum Perspective
    {

        First,
        Third

    };

    public enum ContainerName
    {

        container1p,
        container3p

    };

    [SerializeField]
    private Perspective perspective = Perspective.Third;

    Dictionary<Perspective, ContainerName> containerNameByPerspective = new Dictionary<Perspective, ContainerName>();
    Dictionary<ContainerName, Transform> containerByName = new Dictionary<ContainerName, Transform>();

    // Start is called before the first frame update
    void Start()
    {

        InitialiseContainers();
        PerspectiveSwitch(perspective);

    }

    void InitialiseContainers()
    {

        containerNameByPerspective.Add(Perspective.First, ContainerName.container1p);
        containerNameByPerspective.Add(Perspective.Third, ContainerName.container3p);

        containerByName.Add(ContainerName.container1p, gameObject.transform.Find(ContainerName.container1p.ToString()));
        containerByName.Add(ContainerName.container3p, gameObject.transform.Find(ContainerName.container3p.ToString()));

    }

    void DisableAllContainers()
    {

        foreach(KeyValuePair<ContainerName, Transform> container in containerByName)
        {

            container.Value.gameObject.SetActive(false);

        }

    }

    void ActivePerspective(Perspective perspective)
    {

        ContainerName container;
        if(containerNameByPerspective.TryGetValue(perspective, out container))
        {

            if(containerByName.TryGetValue(container, out Transform transform))
            {
                transform.gameObject.SetActive(true);
            }

        }

    }

    void PerspectiveSwitch(Perspective perspective)
    {

        DisableAllContainers();
        ActivePerspective(perspective);

    }

    public Perspective GetPerspective()
    {

        return perspective;

    }

    public void SetPerspective(Perspective perspective)
    {

        if(this.perspective == perspective)
        {
            return;
        }
        this.perspective = perspective;

        PerspectiveSwitch(perspective);
    }


}

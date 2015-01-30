// Copyright © 2014 Pixelnest Studio
// This file is subject to the terms and conditions defined in
// file 'LICENSE.md', which is part of this source code package.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pixelnest.BulletML
{
  /// <summary>
  /// Projectile launcher.
  /// </summary>
#if UNITY_EDITOR
  [AddComponentMenu("BulletML/Bullet Source")]
#endif
  public class BulletSourceScript : MonoBehaviour
  {
    private static Dictionary<TextAsset, BulletMLLib.BulletPattern> patternCache = new Dictionary<TextAsset, BulletMLLib.BulletPattern>();

    /// <summary>
    /// The XML pattern we want to use.
    /// </summary>
    public TextAsset xmlFile;

    private TopBullet rootBullet;
    private BulletMLLib.BulletPattern pattern;
    private BulletMLLib.IBulletManager bulletManager;

    void Start()
    {
      // Note: we use start and not Awake so the BulletManager has some time to initialiez BulletML properly.

      // Find the manager
      bulletManager = FindObjectOfType<BulletManagerScript>();
      if (bulletManager == null)
      {
        throw new System.Exception("Cannot find a BulletManagerScript in the scene!");
      }

      // Parse pattern
      if (xmlFile == null)
      {
        throw new System.Exception("No pattern (Xml File) assigned to the emitter.");
      }

      // Cache the pattern to avoid reparsing everytime
      if (patternCache.TryGetValue(xmlFile, out pattern) == false)
      {
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(new System.IO.StringReader(xmlFile.text));
        reader.Normalization = false;
        reader.XmlResolver = null;

        pattern = new BulletMLLib.BulletPattern();
        pattern.ParseXML(xmlFile.name, reader);

        patternCache.Add(xmlFile, pattern);
      }

      Initialize();
    }

    /// <summary>
    /// Restart the whole pattern
    /// </summary>
    public void Reset()
    {
      if (rootBullet != null)
      {
        foreach (var task in rootBullet.Tasks)
        {
          task.HardReset(rootBullet);
        }
      }
    }

    /// <summary>
    /// Setup the emitter with the current pattern
    /// </summary>
    private void Initialize()
    {
      rootBullet = new TopBullet(bulletManager, this);
      rootBullet.X = this.transform.position.x;
      rootBullet.Y = this.transform.position.y;
      rootBullet.InitTopNode(pattern.RootNode);
    }

    void Update()
    {
      rootBullet.X = transform.position.x;
      rootBullet.Y = transform.position.y;
      rootBullet.Update();
    }

    /// <summary>
    /// The pattern is ended
    /// </summary>
    public bool IsEnded
    {
      get
      {
        if (rootBullet == null)
        {
          return false;
        }

        bool ended = true;
        foreach (var t in rootBullet.Tasks)
        {
          ended &= t.TaskFinished;
        }
        return ended;
      }
    }
  }
}
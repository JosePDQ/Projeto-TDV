using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvader
{

    class ColisionM
    {
        List<Alien> al;
        List<Bullet> bul;
        SoundEffect boom;
        ContentManager content;



        public ColisionM(List<Alien> aliens, List<Bullet> bullet, ContentManager content)
        {
            al = aliens;
            bul = bullet;
            boom = content.Load<SoundEffect>("boom");
        }
        public void colision()
        {
            foreach (Bullet b in bul.ToArray())
            {
                foreach (Alien a in al.ToArray())
                {

                    if (b.colisao(a.gethitbox()))
                    {
                        bul.Remove(b);
                        al.Remove(a);
                        boom.Play();
                    }
                    {

                    }

                }
            }
        }
        public bool endgame()
        {
            if (al.ToArray().Length == 0)
                return true;
            else return false;

        }
    }
}

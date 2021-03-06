﻿/*--------------------------------------------------------------------------

Reactor.Web.Sockets

The MIT License (MIT)

Copyright (c) 2015 Haydn Paterson (sinclair) <haydn.developer@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

---------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Reactor.Web.Socket
{
    public class Context
    {
        public Reactor.Http.ServerRequest               Request           { get; set; }

        public Reactor.Http.ServerResponse              Response          { get; set; }

        public Reactor.Http.ServerConnection            Connection        { get; set; }

        public System.Security.Principal.IPrincipal User              { get; set; }

        private Dictionary<string, object>          userdata;

        public Context(Reactor.Http.HttpContext context)
        {
            this.Request = context.Request;

            this.Response = context.Response;

            this.Connection = context.Connection;

            this.User = context.User;

            this.userdata = new Dictionary<string, object>();
        }

        public void Set<T>(string name, T value)
        {
            this.userdata[name] = value;
        }

        public T Get<T>(string name)
        {
            if (!this.userdata.ContainsKey(name))
            {
                return default(T);
            }

            try
            {
                return (T)this.userdata[name];
            }
            catch
            {
                return default(T);
            }
        }
    }
}

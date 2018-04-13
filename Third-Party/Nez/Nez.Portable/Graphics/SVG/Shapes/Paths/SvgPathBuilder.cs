using System.Collections.Generic;
using Microsoft.Xna.Framework;


// IMPORTANT NOTE! THIS CLASS IS NOT COMPILED INTO THE NEZ PCL! YOU MUST ADD THIS CLASS MANUALLY TO YOUR MAIN PROJECT TO USE IT.

namespace Nez.Svg
{
	/// <summary>
	/// helper class used to parse paths and also fetch the drawing points from a series of SvgPathSegments
	/// </summary>
	public class SvgPathBuilder : ISvgPathBuilder
	{

		/// <summary>
		/// takes in a parsed path and returns a list of points that can be used to draw the path
		/// </summary>
		/// <returns>The drawing points.</returns>
		/// <param name="segments">Segments.</param>
		public Vector2[] getDrawingPoints( List<SvgPathSegment> segments, float flatness = 3 )
		{

			var path = new PathBuilder();
			for( var j = 0; j < segments.Count; j++ )
			{
				var segment = segments[j];
				if( segment is SvgMoveToSegment )
				{
					path.AddPoint(segment.start);
				}
				else if( segment is SvgCubicCurveSegment )
				{
					var cubicSegment = segment as SvgCubicCurveSegment;
					
					path.AddBezier(segment.start, cubicSegment.firstCtrlPoint, cubicSegment.secondCtrlPoint, segment.end);
				}
				else if( segment is SvgClosePathSegment )
				{
					if (path.Count > 0 && !path.Buffer[0].Equals(path.Buffer[path.Count - 1]))
					{
						path.ClosePath();
					}
				}
				else if( segment is SvgLineSegment )
				{
					path.AddPoint(segment.start);
					path.AddPoint(segment.end);
				}
				else if( segment is SvgQuadraticCurveSegment )
				{
					var quadSegment = segment as SvgQuadraticCurveSegment;
					
					var segmentArray = new Vector2[] {segment.end, quadSegment.secondCtrlPoint, quadSegment.firstCtrlPoint, segment.end};
					
					path.AddBeziers(segmentArray, BezierType.Quadratic);	
				}
				else
				{
					Debug.warn( "unknown type in getDrawingPoints" );
				}
			}

			return path.Buffer;
		}
	}
}

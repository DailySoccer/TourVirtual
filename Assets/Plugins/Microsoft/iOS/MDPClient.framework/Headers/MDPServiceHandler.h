//
//  MDPServiceHandler.h
//  MDPClient
//
//  Created by Javier Ovejero on 16/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

@import Foundation;
@import CoreData;


#pragma mark - Interface
@interface MDPServiceHandler : NSObject
+ (NSManagedObjectContext *)mainManagedObjectContext;
+ (BOOL)refreshIsNeededForObjectsArray:(NSArray *)objects;
+ (BOOL)refreshIsNeededForObjectWithExpirationTime:(NSTimeInterval)modelExpTime lastUpdate:(NSDate *)lastUpdateDate;
+ (NSDate *)translateFromServerNumberToDate:(id)number;
+ (id)translateNullToNil:(id)object;
+ (void)deleteOldObjects:(NSSet *)oldObjects newObjects:(NSSet *)newObjects;
+ (NSDate *)dateFromDateString:(NSString *)dateString timeString:(NSString *)timeString;

@end

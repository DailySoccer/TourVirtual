//
//  NSManagedObject+MDPManagedObject.h
//  MDPClient
//
//  Created by Ernesto Fernández Calles on 26/12/14.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import <CoreData/CoreData.h>


#pragma mark - Constants
typedef enum NSTimeInterval{
    MDPManagedObjectModelRefreshFrequencyAlways                  = 0,
    MDPManagedObjectModelRefreshFrequencyNearlyAlways            = 60,       // 1 minute
    MDPManagedObjectModelRefreshFrequencyFiveMinutes             = 300,      // 5 minutes
    MDPManagedObjectModelRefreshFrequencyNearlyFrequently        = 1800,     // 30 minutes
    MDPManagedObjectModelRefreshFrequencyFrequently              = 3600,     // 1 hour
    MDPManagedObjectModelRefreshFrequencyRarely                  = 86400,    // 1 day
    MDPManagedObjectModelRefreshFrequencyNever                   = 2678400   // 1 month
    
} MDPManagedObjectModelRefreshFrequency;


#pragma mark - Interface
@interface NSManagedObject (MDPManagedObject)


#pragma mark - Entity
+ (NSString *)entityName;
+ (NSEntityDescription *)entityInManagedObjectContext:(NSManagedObjectContext *)managedObjectContext;
+ (instancetype)insertNewObjectInManagedObjectContext:(NSManagedObjectContext *)managedObjectContext;
+ (void)deleteExistingObjectsInManagedObjectContext:(NSManagedObjectContext *)managedObjectContext;
- (void)deleteSet:(NSSet *)set inManagedObjectContext:(NSManagedObjectContext *)managedObjectContext;

#pragma mark - Entity
+ (NSFetchRequest *)fetchRequest;


#pragma mark - Fetch Objects
+ (NSArray *)allObjectsInManagedObjectContext:(NSManagedObjectContext *)managedObjectContext error:(NSError *__autoreleasing *)error;

+ (NSArray *)allObjectsFilteredByPredicate:(NSPredicate *)predicate
                  orderedBySortDescriptors:(NSArray *)sortDescriptors
                                fetchLimit:(NSUInteger)fetchLimit
                               fetchOffset:(NSUInteger)fetchOffset
                            fetchBatchSize:(NSUInteger)fetchBatchSize
        relationshipKeyPathsForPrefetching:(NSArray *)relationshipKeyPathsForPrefetching
                    inManagedObjectContext:(NSManagedObjectContext *)managedObjectContext
                                     error:(NSError *__autoreleasing *)error;

+ (instancetype)objectWithValue:(id)value forKeyPath:(NSString *)keyPath
           insertIfDoesNotExist:(BOOL)insertIfDoesNotExist
         inManagedObjectContext:(NSManagedObjectContext *)managedObjectContext
                          error:(NSError *__autoreleasing *)error;

+ (instancetype)objectWithValuesForKeyPaths:(NSDictionary *)valuesAndKeyPathsDictionary
                       insertIfDoesNotExist:(BOOL)insertIfDoesNotExist
                     inManagedObjectContext:(NSManagedObjectContext *)managedObjectContext
                                      error:(NSError *__autoreleasing *)error;


#pragma mark - Expiration
- (NSTimeInterval)expirationTimeInterval;
- (NSTimeInterval)expirationTimeIntervalForKey:(NSString *)key;
- (NSDate *)expirationLastUpdate;


#pragma mark - Validation
- (BOOL)isValid;


#pragma mark - Fill
+ (NSString *)keyStringInJsonForKey:(NSString *)entityKey context:(NSManagedObjectContext *)context;
//- (NSString *)keyStringInJsonForKey:(NSString *)entityKey;
- (void)fillWithInfo:(NSDictionary *)info;

@end
















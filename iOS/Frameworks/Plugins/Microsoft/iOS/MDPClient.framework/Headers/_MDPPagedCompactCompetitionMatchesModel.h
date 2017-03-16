//
//  _MDPPagedCompactCompetitionMatchesModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedCompactCompetitionMatchesModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedCompactCompetitionMatchesModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *totalCount;
} MDPPagedCompactCompetitionMatchesModelAttributes;

extern const struct MDPPagedCompactCompetitionMatchesModelRelationships {
	__unsafe_unretained NSString *items;
	__unsafe_unretained NSString *pagedCompactCompetitionMatchesRequest;
} MDPPagedCompactCompetitionMatchesModelRelationships;

@class MDPCompactCompetitionMatchModel;
@class MDPPagedCompactCompetitionMatchesRequestModel;

@interface _MDPPagedCompactCompetitionMatchesModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalCount;

@property (atomic) int64_t totalCountValue;
- (int64_t)totalCountValue;
- (void)setTotalCountValue:(int64_t)value_;

//- (BOOL)validateTotalCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *items;

- (NSMutableSet*)itemsSet;

@property (nonatomic, strong) MDPPagedCompactCompetitionMatchesRequestModel *pagedCompactCompetitionMatchesRequest;

//- (BOOL)validatePagedCompactCompetitionMatchesRequest:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPagedCompactCompetitionMatchesModel (ItemsCoreDataGeneratedAccessors)
- (void)addItems:(NSSet*)value_;
- (void)removeItems:(NSSet*)value_;
- (void)addItemsObject:(MDPCompactCompetitionMatchModel*)value_;
- (void)removeItemsObject:(MDPCompactCompetitionMatchModel*)value_;
@end

@interface _MDPPagedCompactCompetitionMatchesModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveTotalCount;
- (void)setPrimitiveTotalCount:(NSNumber*)value;

- (int64_t)primitiveTotalCountValue;
- (void)setPrimitiveTotalCountValue:(int64_t)value_;

- (NSMutableSet*)primitiveItems;
- (void)setPrimitiveItems:(NSMutableSet*)value;

- (MDPPagedCompactCompetitionMatchesRequestModel*)primitivePagedCompactCompetitionMatchesRequest;
- (void)setPrimitivePagedCompactCompetitionMatchesRequest:(MDPPagedCompactCompetitionMatchesRequestModel*)value;

@end

//
//  _MDPPagedFanGamingScoreHistoryModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedFanGamingScoreHistoryModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedFanGamingScoreHistoryModelAttributes {
	__unsafe_unretained NSString *continuationToken;
	__unsafe_unretained NSString *continuationTokenB64;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPPagedFanGamingScoreHistoryModelAttributes;

extern const struct MDPPagedFanGamingScoreHistoryModelRelationships {
	__unsafe_unretained NSString *pagedFanGamingScoreHistoryRequest;
	__unsafe_unretained NSString *results;
} MDPPagedFanGamingScoreHistoryModelRelationships;

@class MDPPagedFanGamingScoreHistoryRequestModel;
@class MDPFanGamingScoreHistoryModel;

@interface _MDPPagedFanGamingScoreHistoryModel : NSManagedObject

@property (nonatomic, strong) NSString* continuationToken;

//- (BOOL)validateContinuationToken:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* continuationTokenB64;

//- (BOOL)validateContinuationTokenB64:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasMoreResults;

@property (atomic) BOOL hasMoreResultsValue;
- (BOOL)hasMoreResultsValue;
- (void)setHasMoreResultsValue:(BOOL)value_;

//- (BOOL)validateHasMoreResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedFanGamingScoreHistoryRequestModel *pagedFanGamingScoreHistoryRequest;

//- (BOOL)validatePagedFanGamingScoreHistoryRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *results;

- (NSMutableOrderedSet*)resultsSet;

@end

@interface _MDPPagedFanGamingScoreHistoryModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSOrderedSet*)value_;
- (void)removeResults:(NSOrderedSet*)value_;
- (void)addResultsObject:(MDPFanGamingScoreHistoryModel*)value_;
- (void)removeResultsObject:(MDPFanGamingScoreHistoryModel*)value_;
@end

@interface _MDPPagedFanGamingScoreHistoryModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveContinuationToken;
- (void)setPrimitiveContinuationToken:(NSString*)value;

- (NSString*)primitiveContinuationTokenB64;
- (void)setPrimitiveContinuationTokenB64:(NSString*)value;

- (NSNumber*)primitiveHasMoreResults;
- (void)setPrimitiveHasMoreResults:(NSNumber*)value;

- (BOOL)primitiveHasMoreResultsValue;
- (void)setPrimitiveHasMoreResultsValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPPagedFanGamingScoreHistoryRequestModel*)primitivePagedFanGamingScoreHistoryRequest;
- (void)setPrimitivePagedFanGamingScoreHistoryRequest:(MDPPagedFanGamingScoreHistoryRequestModel*)value;

- (NSMutableOrderedSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableOrderedSet*)value;

@end

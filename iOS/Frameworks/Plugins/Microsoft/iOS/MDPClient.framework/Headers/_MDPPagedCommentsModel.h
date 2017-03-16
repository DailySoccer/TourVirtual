//
//  _MDPPagedCommentsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedCommentsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedCommentsModelAttributes {
	__unsafe_unretained NSString *continuationToken;
	__unsafe_unretained NSString *continuationTokenB64;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPPagedCommentsModelAttributes;

extern const struct MDPPagedCommentsModelRelationships {
	__unsafe_unretained NSString *pagedCommentsRequest;
	__unsafe_unretained NSString *results;
} MDPPagedCommentsModelRelationships;

@class MDPPagedCommentsRequestModel;
@class MDPCommentModel;

@interface _MDPPagedCommentsModel : NSManagedObject

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

@property (nonatomic, strong) MDPPagedCommentsRequestModel *pagedCommentsRequest;

//- (BOOL)validatePagedCommentsRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *results;

- (NSMutableSet*)resultsSet;

@end

@interface _MDPPagedCommentsModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSSet*)value_;
- (void)removeResults:(NSSet*)value_;
- (void)addResultsObject:(MDPCommentModel*)value_;
- (void)removeResultsObject:(MDPCommentModel*)value_;
@end

@interface _MDPPagedCommentsModel (CoreDataGeneratedPrimitiveAccessors)

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

- (MDPPagedCommentsRequestModel*)primitivePagedCommentsRequest;
- (void)setPrimitivePagedCommentsRequest:(MDPPagedCommentsRequestModel*)value;

- (NSMutableSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableSet*)value;

@end

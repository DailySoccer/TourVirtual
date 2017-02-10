//
//  _MDPPagedIndexedGroupsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedIndexedGroupsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedIndexedGroupsModelAttributes {
	__unsafe_unretained NSString *count;
	__unsafe_unretained NSString *currentPage;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *totalPages;
} MDPPagedIndexedGroupsModelAttributes;

extern const struct MDPPagedIndexedGroupsModelRelationships {
	__unsafe_unretained NSString *pagedIndexedGroupsRequest;
	__unsafe_unretained NSString *results;
} MDPPagedIndexedGroupsModelRelationships;

@class MDPPagedIndexedGroupsRequestModel;
@class MDPIndexedGroupModel;

@interface _MDPPagedIndexedGroupsModel : NSManagedObject

@property (nonatomic, strong) NSNumber* count;

@property (atomic) int64_t countValue;
- (int64_t)countValue;
- (void)setCountValue:(int64_t)value_;

//- (BOOL)validateCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* currentPage;

@property (atomic) int64_t currentPageValue;
- (int64_t)currentPageValue;
- (void)setCurrentPageValue:(int64_t)value_;

//- (BOOL)validateCurrentPage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasMoreResults;

@property (atomic) BOOL hasMoreResultsValue;
- (BOOL)hasMoreResultsValue;
- (void)setHasMoreResultsValue:(BOOL)value_;

//- (BOOL)validateHasMoreResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* totalPages;

//- (BOOL)validateTotalPages:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedIndexedGroupsRequestModel *pagedIndexedGroupsRequest;

//- (BOOL)validatePagedIndexedGroupsRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *results;

- (NSMutableSet*)resultsSet;

@end

@interface _MDPPagedIndexedGroupsModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSSet*)value_;
- (void)removeResults:(NSSet*)value_;
- (void)addResultsObject:(MDPIndexedGroupModel*)value_;
- (void)removeResultsObject:(MDPIndexedGroupModel*)value_;
@end

@interface _MDPPagedIndexedGroupsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCount;
- (void)setPrimitiveCount:(NSNumber*)value;

- (int64_t)primitiveCountValue;
- (void)setPrimitiveCountValue:(int64_t)value_;

- (NSNumber*)primitiveCurrentPage;
- (void)setPrimitiveCurrentPage:(NSNumber*)value;

- (int64_t)primitiveCurrentPageValue;
- (void)setPrimitiveCurrentPageValue:(int64_t)value_;

- (NSNumber*)primitiveHasMoreResults;
- (void)setPrimitiveHasMoreResults:(NSNumber*)value;

- (BOOL)primitiveHasMoreResultsValue;
- (void)setPrimitiveHasMoreResultsValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDecimalNumber*)primitiveTotalPages;
- (void)setPrimitiveTotalPages:(NSDecimalNumber*)value;

- (MDPPagedIndexedGroupsRequestModel*)primitivePagedIndexedGroupsRequest;
- (void)setPrimitivePagedIndexedGroupsRequest:(MDPPagedIndexedGroupsRequestModel*)value;

- (NSMutableSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableSet*)value;

@end
